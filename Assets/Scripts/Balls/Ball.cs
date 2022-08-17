using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TrailRenderer _trailRenderer;
    [SerializeField] private Rigidbody2D _body;
    [SerializeField] private float _startingYVel = 5;
    [SerializeField] private float _raycastDistance = 2;

    // Property to get the starting velocity
    public float StartingYVel => _startingYVel;

    private Vector2 _previousVelocity;
    private Coroutine _runningCoroutine;

    private void Start()
    {
        // Draw two first points of line
        _lineRenderer.positionCount = 2;

        Vector3 startPosition = transform.position;
        _lineRenderer.SetPosition(0, startPosition);
        _lineRenderer.SetPosition(1, startPosition);

        // Start coroutine to update line
        _runningCoroutine = StartCoroutine(DrawLineBehindBall());

        // Set color of sprite
        _spriteRenderer.color = Color.white;
        _trailRenderer.startColor = Color.white;
        _trailRenderer.endColor = Color.white;
    }

    private void FixedUpdate()
    {
        // Update previous position
        _previousVelocity = _body.velocity;
        
        // Stop updating line if number of point is greater than 100
        if (_lineRenderer.positionCount > 100)
        {
            StopCoroutine(_runningCoroutine);
        }
        
        // Raycast to check if ball will hit a brick
        RaycastHit2D hit = Physics2D.Raycast(transform.position, _body.velocity, _raycastDistance, LayerMask.GetMask("Destructible"));

        if (hit.collider == null)
        {
            // No brick is touch, every thing is white
            _spriteRenderer.color = Color.white;
            _trailRenderer.startColor = Color.white;
            _trailRenderer.endColor = Color.white;
        }
        else
        {
            // Get the distance between the ball and the collider hit
            float distance = Vector2.Distance(transform.position, hit.collider.transform.position);
            
            // Set the color by lerping between red and white
            Color col = Color.Lerp(Color.red, Color.white, distance / _raycastDistance);
            _spriteRenderer.color = col;
            _trailRenderer.startColor = col;
            _trailRenderer.endColor = col;
        }
    }

    private IEnumerator DrawLineBehindBall()
    {
        // Infinite loop to draw line
        while (true)
        {
            _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, transform.position);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            // If hit the player then copy the horizontal velocity  
            Vector2 newVelocity = other.rigidbody.velocity;
            newVelocity.y = _startingYVel;
            _body.velocity = newVelocity;
        }
        else
        {
            // If hit a wall then get the normal
            Vector2 normal = other.GetContact(0).normal;

            Vector2 vel = _previousVelocity;
            
            // Change the velocity 
            if (normal.y < 0 && _previousVelocity.y > 0)
            {
                vel.y = _previousVelocity.y * -1;
            }
            if (normal.y > 0 && _previousVelocity.y < 0)
            {
                vel.y = _previousVelocity.y * -1;
            }
        
            if (normal.x < 0 && _previousVelocity.x > 0)
            {
                vel.x = _previousVelocity.x * -1;
            }
            if (normal.x > 0 && _previousVelocity.x < 0)
            {
                vel.x = _previousVelocity.x * -1;
            }
            _body.velocity = vel;   
        }
        
        // Add position to line renderer
        var collisionPosition = other.GetContact(0).point;

        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, collisionPosition);
    }

    private void OnDrawGizmos()
    {
        var startPosition = transform.position;
        Gizmos.DrawLine(startPosition, startPosition + (Vector3)_body.velocity);
    }
}
