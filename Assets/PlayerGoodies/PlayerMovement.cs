using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour {
    
    Vector3 velocity = new Vector3(0.0f, 1.0f, 0.0f);
    float floorHeight = 0.0f;
    float sleepThreshold = 0.05f;
    public int jumpSpeed = 3;
    public float gravity = -9.8f;
    public float alpha = 1;
    bool onGround;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        if (velocity.magnitude > sleepThreshold || transform.position.y > floorHeight)
        {
            onGround = false;
            velocity += new Vector3(0.0f, gravity * Time.fixedDeltaTime, 0.0f);
        }

        transform.position += velocity * Time.fixedDeltaTime;
        if (transform.position.y <= floorHeight)
        {
            onGround = true;
            transform.position = new Vector3(transform.position.x, floorHeight, transform.position.z);
            velocity.y = 0;
        }
        
    }
    
    // Update is called once per frame
    void Update () {
        if (!hasAuthority)
        {
            return;
        }
        int vel_x = 0;
        int vel_y = 0;
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            vel_y = jumpSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            vel_x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel_y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel_x = 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            vel_y = jumpSpeed;
        }
        
        velocity = new Vector3(vel_x, vel_y, 0.0f);
        
        
    }
}
