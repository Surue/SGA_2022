using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Bricks")]
public class BricksInitData : ScriptableObject
{
    [Header("Gameplay")]
    [SerializeField][Range(1, 100)] private int _maxLifePoints = 1;
    [Space]
    [SerializeField] private int _score = 1;
    
    [Header("Art")]
    [SerializeField] private Color _color;
    [SerializeField][Tooltip("A particle system played when the object is destroyed")] private ParticleSystem _particleSystem;
    
    [Header("Sound")]
    [SerializeField] private AudioClip _audioClip;
    [SerializeField][Range(0, 2)] private float _fadeOutDuration;

    /// <summary>
    /// Get the maximum life points
    /// </summary>
    /// <returns></returns>
    public int GetMaxLifePoints()
    {
        return _maxLifePoints;
    }

    /// <summary>
    /// Get the score to win when destroying the brick
    /// </summary>
    /// <returns></returns>
    public int GetScore()
    {
        return _score;
    }
}

