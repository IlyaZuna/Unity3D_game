using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ControlSceneAndMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsSettings;
    public GameObject LoadingScreen;

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
}
