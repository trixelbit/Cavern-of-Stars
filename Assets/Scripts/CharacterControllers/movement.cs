using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Direction
{ 
    down = 0,
    downleft = 1,
    downright = 2,
    left = 3,
    right = 4,
    up = 5,
    upleft = 6,
    upright = 7
    
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
    public float DashSpeed = 3;
    public float FrictionPercent = .01f;

    public Direction Direction = Direction.down;
    public State CharacterState = State.idle;

    private PlayerContolBridge PlayerActionControl;

    public GameObject Slash1;

    private void Awake()
    {
        PlayerActionControl = new PlayerContolBridge();

    }

    private void OnEnable()
    {
        PlayerActionControl.Enable();
        
    }

    private void OnDisable()
    {
        PlayerActionControl.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        
        PlayerActionControl.InGame.Attack1.performed += _ => LightSlash();
    }
    


    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 velocity = rb.velocity;
        float VerticalInput = PlayerActionControl.InGame.Vertical.ReadValue<float>();
        float HorizontalInput = PlayerActionControl.InGame.Horizontal.ReadValue<float>();
        bool Attack1 = PlayerActionControl.InGame.Attack1.triggered;


        // state checks

        
        // kinetic motion
        if (State.slash != CharacterState)
        {

            // directino input-
            if (HorizontalInput != 0 && VerticalInput != 0)
            {
                rb.velocity = new Vector3(HorizontalInput * RunSpeed * (float)Math.Sqrt(.5), rb.velocity.y, VerticalInput * RunSpeed * (float)Math.Sqrt(.5));

                CharacterState = State.running;
            }
            else if (HorizontalInput != 0 || VerticalInput != 0)
            {
                rb.velocity = new Vector3(HorizontalInput * RunSpeed, rb.velocity.y, VerticalInput * RunSpeed);
                CharacterState = State.running;
            }
            else
            {
                rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0, 0, 0), FrictionPercent);
                CharacterState = State.idle;
            }

            // set animation variables
            SetPlayerDirection(HorizontalInput, VerticalInput);
        }
        

    }

    private void LightSlash()
    {
        CharacterState = State.slash;


        rb.velocity = GetVector3FromDirection(Direction, 10);
        GameObject Attack = Instantiate(Slash1);
        Attack.transform.position = transform.position;
        Attack.GetComponent<AttackVFX>().InitialVelocity = rb.velocity;
        Attack.transform.rotation = Quaternion.Euler(0,0,AngleFromDirection(Direction));

    }

    private Vector3 GetVector3FromDirection(Direction direction, float magnitude)
    {
        Vector3 result;
        switch (direction)
        {
            case Direction.up:
                result = new Vector3(rb.velocity.x, rb.velocity.y, magnitude);

                break;
            case Direction.down:
                result = new Vector3(rb.velocity.x, rb.velocity.y, -magnitude);
                break;

            case Direction.left:
                break;

        }
        
    }

    private void SetPlayerDirection( float HorizontalInput, float VerticalInput)
    {
        if (HorizontalInput > 0)
        {

            if (VerticalInput > 0)
            {
                Direction = Direction.upright;
            }
            else if (VerticalInput < 0)
            {
                Direction = Direction.downright;
            }
            else
            {
                Direction = Direction.right;
            }
        }
        else if (HorizontalInput < 0)
        {
            if (VerticalInput > 0)
            {
                Direction = Direction.upleft;
            }
            else if (VerticalInput < 0)
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
            if (VerticalInput > 0)
            {
                Direction = Direction.up;
            }
            else if (VerticalInput < 0)
            {
                Direction = Direction.down;
            }
        }
    }

    private float AngleFromDirection(Direction direction)
    {
        float angle = 0;

        switch(direction)
        {
            case Direction.down:
                angle = 270;
                break;

            case Direction.downleft:
                angle = 225;
                break;
            case Direction.downright:
                angle = 315;
                break;
            case Direction.left:
                angle = 180;
                break;
            case Direction.right:
                angle = 0;
                break;
            case Direction.up:
                angle = 90;
                break;
            case Direction.upleft:
                angle = 135;
                break;
            case Direction.upright:
                angle = 45;
                break;

        }

        return angle;
    }

 
}
