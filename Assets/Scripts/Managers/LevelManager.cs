using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textRemaingBricks;
    [SerializeField] private TextMeshProUGUI _textTotalBricks;
    
    private int _countTotalBricks;
    private int _countRemainingBricks;
    
    void Start()
    {
        // Get all bricks in the scene
        DestructibleBrick[] bricks = FindObjectsOfType<DestructibleBrick>();

        // Set LevelManager for every brick in the level
        foreach (var destructibleBrick in bricks)
        {
            destructibleBrick.SetupLevelManager(this);
        }

        // Set counter
        _countTotalBricks = bricks.Length;
        _countRemainingBricks = bricks.Length;

        // Update UI
        _textRemaingBricks.text = _countRemainingBricks.ToString();
        _textTotalBricks.text = _countTotalBricks.ToString();
    }

    /// <summary>
    /// Destroy a brick in the levelManager and update UI
    /// </summary>
    public void OnDestroyBrick()
    {
        _countRemainingBricks--;
        _textRemaingBricks.text = _countRemainingBricks.ToString();
    }
}
