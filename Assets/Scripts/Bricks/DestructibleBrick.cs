using UnityEngine;

public class DestructibleBrick : MonoBehaviour
{
    [SerializeField] public BricksInitData _bricksInitData;

    private LevelManager _levelManager;
    
    private int _lifePoints = 1;
    private int _score;
    
    void Start()
    {
        _lifePoints = _bricksInitData.GetMaxLifePoints();
        _score = _bricksInitData.GetScore();
    }

    public void SetupLevelManager(LevelManager levelManager)
    {
        _levelManager = levelManager;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Reduce life
        _lifePoints--;

        if (_lifePoints > 0) return;
        
        // If lifePoints if below zero => Destroy the brick
        _levelManager.OnDestroyBrick();
        Destroy(gameObject);
    }
}
