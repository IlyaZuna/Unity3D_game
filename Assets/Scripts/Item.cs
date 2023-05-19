using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameBehavior _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void OnTriggerEnter(Collider other)
    {
        _gameManager.Items += 1;
        Destroy(gameObject);
    }
}
