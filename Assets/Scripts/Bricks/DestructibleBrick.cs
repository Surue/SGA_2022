using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBrick : MonoBehaviour
{
    public int lifePoints = 1;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (lifePoints <= 0)
        {
            Destroy(gameObject);
        }   
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        lifePoints--;
    }
}
