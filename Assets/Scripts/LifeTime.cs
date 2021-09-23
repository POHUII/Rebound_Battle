using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    private float minLifeTime = 3;
    private float maxLifeTime = 6;
    private float lifeTime = 0;
    private void Start()
    {
        lifeTime = Random.Range(minLifeTime, maxLifeTime);
        Destroy(gameObject, lifeTime);
    }
}
