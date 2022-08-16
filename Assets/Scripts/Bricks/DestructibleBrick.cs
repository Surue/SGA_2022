using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleBrick : MonoBehaviour
{
    [SerializeField] public BricksInitData _bricksInitData;
    
    private int _lifePoints = 1;
    private int _score;

    private static int count;  
    
    void Start()
    {
        _lifePoints = _bricksInitData.GetMaxLifePoints();
        _score = _bricksInitData.GetScore();
        
        count += 1;

        LogCount();
    }

    public static void LogCount()
    {
        Debug.Log("Count = " + count);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _lifePoints--;
        
        if (_lifePoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
