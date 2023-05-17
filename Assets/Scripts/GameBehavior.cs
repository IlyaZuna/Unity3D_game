using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;
    private int _enemyHP = 10;

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }

    public int P_HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }

    public int E_HP
    {
        get { return _enemyHP; }
        set
        {
            _enemyHP = value;
            Debug.LogFormat("Enemy_Lives: {0}", _enemyHP);
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
