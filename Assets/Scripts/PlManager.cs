using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlManager : MonoBehaviour
{
    public float health, bulletSpeed;

    bool dead = false;

    Transform barrel;

    public Transform bullet; /*,floatingText*/

    public Slider slider;
    bool mouseIsNotOverUI;
    // Start is called before the first frame update
    void Start()
    {
        barrel = transform.GetChild(3);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI = EventSystem.current.currentSelectedGameObject == null;
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI) 
        {
            ShootBullet();
        }
    }

    public void GetDamage(float damage)
    {
        //Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();

        if ((health - damage) >= 0)
        {
            health -= damage;
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();
    }
    void AmIDead()
    {
        if (health <= 0)
        {
            DataManager.instance.LoseProcess();
            dead = true;
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, barrel.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(barrel.forward * bulletSpeed);
        DataManager.instance.ShotBullet++;
    }
}