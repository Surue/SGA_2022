using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D body;

    public float startingYVel;

    public Vector2 previousVelocity;

    void FixedUpdate()
    {
        previousVelocity = body.velocity;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            var vel = other.rigidbody.velocity;
            vel.y = startingYVel;
            
            body.velocity = vel;
        }
        else
        {
            var normal = other.GetContact(0).normal;

            Vector2 vel = previousVelocity;
            if (normal.y < 0 && previousVelocity.y > 0)
            {
                vel.y = previousVelocity.y * -1;
            }
            if (normal.y > 0 && previousVelocity.y < 0)
            {
                vel.y = previousVelocity.y * -1;
            }
        
            if (normal.x < 0 && previousVelocity.x > 0)
            {
                vel.x = previousVelocity.x * -1;
            }
            if (normal.x > 0 && previousVelocity.x < 0)
            {
                vel.x = previousVelocity.x * -1;
            }
            body.velocity = vel;   
        }
    }
}
