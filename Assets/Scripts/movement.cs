﻿using System.Collections;
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
    running = 1,
    dash = 2,
    slash = 3
}


public class movement : MonoBehaviour
{   
    
    public Rigidbody rb;

    public float RunSpeed;
    public float DashSpeed;
    public float FrictionPercent = .01f;

    public Direction Direction = Direction.down;
    public State CharacterState = State.idle;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 velocity = rb.velocity;

        // state checks


        // kinetic motion

        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * RunSpeed * (float)Math.Sqrt(.5), rb.velocity.y, Input.GetAxis("Vertical") * RunSpeed * (float)Math.Sqrt(.5));
            
            CharacterState = State.running;
        }
        else if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            rb.velocity = new Vector3(Input.GetAxis("Horizontal") * FrictionPercent, rb.velocity.y, Input.GetAxis("Vertical") * RunSpeed);
            CharacterState = State.running;
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, 0, 0), FrictionPercent);
            CharacterState = State.idle;
        }

        // set animation variables
        SetPlayerDirection();

    }


    private void SetPlayerDirection()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Direction = Direction.upright;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                Direction = Direction.downright;
            }
            else
            {
                Direction = Direction.right;
            }
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Direction = Direction.upleft;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                Direction = Direction.downleft;
            }
            else
            {
                Direction = Direction.left;
            }
        }
        else
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                Direction = Direction.up;
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                Direction = Direction.down;
            }
        }
    }

 
}
