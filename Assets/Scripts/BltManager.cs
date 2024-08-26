using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BltManager : MonoBehaviour
{
    public float bulletDamage, lifeTime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
