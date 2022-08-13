using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position += Vector3.right * (speed * Time.deltaTime);
        }
        
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.position += Vector3.left * (speed * Time.deltaTime);
        }
    }
}
