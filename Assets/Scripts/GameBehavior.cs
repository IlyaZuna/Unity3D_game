using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    //private int _enemyHP = 10;

    public string labelText = "Collect all 7 items and win your freedom!";
    public int maxItems = 7;
    public bool showWinScreen = false;
    public bool showLossScreen = false;

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            if (_itemsCollected >= maxItems)
            {
                labelText = "You’ve found all the items!";
                showWinScreen = true;

                SceneManager.LoadScene("Labirint");
            }

            else
            {
                labelText = "Item found, only " + (maxItems - _itemsCollected) + " more to go!";
            }
        }
    }

    public int P_HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
            
            if (_playerHP <= 0)
            {
                labelText = "YOU WANT ANOTHER LIFE WITH THAT?";
                showLossScreen = true;

                SceneManager.LoadScene("Labirint");
            }

            else
            {
                labelText = "OUCH... THAT'S GOT HURT.";
            }

        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(100, 20, 150, 25), "PLAYER HEALTH:" + _playerHP);

        GUI.Box(new Rect(100, 50, 150, 25), "ITEMS COLLECTED: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 50, 200, 100), "YOU WON!"))
            {
                SceneManager.LoadScene("Labirint");

            }
        }
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
