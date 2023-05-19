using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                labelText = "You want another life with that?";
                showLossScreen = true;
                Time.timeScale = 0;
            }
            else
            {
                labelText = "Ouch... that’s got hurt.";
            }

        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 1500, 25), "Player Health:" + _playerHP);

        GUI.Box(new Rect(20, 50, 1500, 25), "Items Collected: " + _itemsCollected);

        GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 300, 50), labelText);

    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
