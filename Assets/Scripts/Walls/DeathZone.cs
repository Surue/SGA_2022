using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public void OnCollisionEnter2D(Collision2D other)
    {
        // Ignore collision if it's not a ball
        if (!other.gameObject.TryGetComponent(out Ball ball)) return;
        
        // Destroy the ball
        Destroy(other.gameObject);

        // Return to main menu
        GameManager.instance.ReturnMainMenu();
    }
}
