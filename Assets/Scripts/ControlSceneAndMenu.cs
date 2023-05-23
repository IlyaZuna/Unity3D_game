using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlSceneAndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    //public GameObject buttonsPause;
    public GameObject buttonsSettings;
    public GameObject LoadingScreen;
    public GameObject PauseScreen;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }
    
    public void ShowPauseScene()
    {
        PauseScreen.SetActive(true);
    }
    public void ShowGameScene()
    {
        PauseScreen.SetActive(false);
    }

    public void BackInMenu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    } 
    
    public void ExitGame()
    {
        Application.Quit();
    }

   /* public void NewGameLoadSceneLabirint()
    {
        SceneManager.LoadScene("Labirint");
    }*/

    public void LoadScene1()
    {
        buttonsMenu.SetActive(false);
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void LoadSceneMenu()
    {
        LoadingScreen.SetActive(true);
        SceneManager.LoadScene(0);
        //buttonsMenu.SetActive(true);
    }
}