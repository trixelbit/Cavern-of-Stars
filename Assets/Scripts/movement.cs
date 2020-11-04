using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Direction
{ 
    down = 0,
    downright = 1,
    right = 2,
    upright = 3,
    up = 4,
    upleft = 5,
    left = 6,
    downleft = 7
}

public enum State
{ 
    idle = 0,
    running = 1
}


public class movement : MonoBehaviour
{

    public Rigidbody rb;
    public float runSpeed;
    public Direction runDirection = Direction.down;
    public State playerState = State.idle;
    public float drag_percent = .01f;
    
    // Start is called before the first frame update
    private bool up, down, left, right;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        up = Input.GetKey(KeyCode.W);
        down = Input.GetKey(KeyCode.S);
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);

        Vector3 velocity = rb.velocity;

        // state checks


        // kinetic motion

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * runSpeed * (float)Math.Sqrt(.5), rb.velocity.y, Input.GetAxis("Vertical") * runSpeed * (float)Math.Sqrt(.5));
            
            playerState = State.running;
        }
        else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * runSpeed, rb.velocity.y, Input.GetAxis("Vertical") * runSpeed);
            playerState = State.running;
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, 0, 0), drag_percent);
            playerState = State.idle;
        }

        // set animation variables
        SetPlayerDirection();

    }


    public float Sqrt(float a)
    {
        return (float)Math.Sqrt(Math.Pow((double)a, 2) / 2 );
    }


    private void SetPlayerDirection()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                runDirection = Direction.upright;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                runDirection = Direction.downright;
            }
            else
            {
                runDirection = Direction.right;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                runDirection = Direction.upleft;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                runDirection = Direction.downleft;
            }
            else
            {
                runDirection = Direction.left;
            }
        }
        else
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                runDirection = Direction.up;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                runDirection = Direction.down;
            }
        }
    }

 
}
