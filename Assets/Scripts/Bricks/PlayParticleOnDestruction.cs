using UnityEngine;

public class PlayParticleOnDestruction : MonoBehaviour
{
    [SerializeField] private GameObject _prefabParticle;
    
    private void OnDestroy()
    {
        Instantiate(_prefabParticle, transform.position, Quaternion.identity);
    }
}
