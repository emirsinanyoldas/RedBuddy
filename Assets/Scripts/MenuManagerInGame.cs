using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, puaseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        puaseScreen.SetActive(true);
    }
    public void PLayButton() 
    {
        Time.timeScale = 1;
        puaseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }
    public void ReplayButton() 
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void HomeButton() 
    {
        Time.timeScale = 1;
        DataManager.instance.SaveData();
        SceneManager.LoadScene(0);
    }
}
