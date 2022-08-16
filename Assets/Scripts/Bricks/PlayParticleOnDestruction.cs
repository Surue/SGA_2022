using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticleOnDestruction : MonoBehaviour
{
    [SerializeField] private GameObject _prefabParticle;
    
    private void OnDestroy()
    {
        Instantiate(_prefabParticle, transform.position, Quaternion.identity);
    }
}
