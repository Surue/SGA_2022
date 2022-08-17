using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed = 5;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Rigidbody2D _body;

    private Vector2 _velocity;
    private Vector2 _ballOffset;
    
    void Start()
    {
        // Cache the offset of the ball
        _ballOffset = _ball.transform.position - transform.position;
    }

    void Update()
    {
        // Start game 
        if (Input.GetKeyDown(KeyCode.Space) && _ball != null)
        {
            var vel = new Vector2
            {
                x = _body.velocity.x, 
                y =  _ball.GetComponent<Ball>().StartingYVel
            };
            _ball.GetComponent<Rigidbody2D>().velocity = vel;

            _ball = null;
        }
        
        // Stick ball to player
        if (_ball != null)
        {
            _ball.transform.position = transform.position + (Vector3)_ballOffset;
        }
        
        // Movements
        if (Input.GetAxis("Horizontal") > 0)
        {
            // Right movement
            _velocity = Vector2.right * _speed;
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            // Left movement
            _velocity = Vector2.left * _speed;
        }
        else
        {
            // No input => set the velocity to zero
            _velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        _body.velocity = _velocity * Time.fixedDeltaTime;
    }
}
