using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;

    public GameObject ball;

    public Rigidbody2D body;

    private Vector2 velocity;
    
    void Start()
    {
        
    }

    void Update()
    {
        // Start game 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var vel = new Vector2
            {
                x = body.velocity.x, 
                y =  ball.GetComponent<Ball>().startingYVel
            };
            ball.GetComponent<Rigidbody2D>().velocity = vel;
        }
        
        // Right movement
        if (Input.GetAxis("Horizontal") > 0)
        {
            velocity = Vector2.right * speed;
        } else if (Input.GetAxis("Horizontal") < 0)
        {
            velocity = Vector2.left * speed;
        }
        else
        {
            velocity = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        body.velocity = velocity * Time.fixedDeltaTime;
    }
}
