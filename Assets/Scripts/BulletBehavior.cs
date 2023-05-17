using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float onscreenDelay = 0.5f;
    void Start()
    {
        Destroy(this.gameObject, onscreenDelay);
    }
}
