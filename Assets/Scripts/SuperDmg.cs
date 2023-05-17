using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperDmg : MonoBehaviour
{
    private GameBehavior _gameManager;

    void Start()
    {
       _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            _gameManager.P_HP -= 2;
        }
    }
}
