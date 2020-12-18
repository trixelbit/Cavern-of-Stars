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
    public GameObject SpritePlane;
    public GameObject HurtVFX;

    public float RunSpeed;
    public float DashSpeed = 3;
    public float FrictionPercent = .01f;

    public Direction Direction = Direction.down;
    public State CharacterState = State.idle;
    public bool Invincible = false;

    private PlayerContolBridge PlayerActionControl;
    private bool stun = false;

    public GameObject Slash1;

    #region Unity Behaviors
    private void Awake()
    {
        PlayerActionControl = new PlayerContolBridge();
        SessionData.Player = gameObject;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        PlayerActionControl.InGame.Attack1.performed += _ => LightSlash();
        PlayerActionControl.InGame.Dash.performed += _ => StartDash();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 velocity = rb.velocity;
        float VerticalInput = PlayerActionControl.InGame.Vertical.ReadValue<float>();
        float HorizontalInput = PlayerActionControl.InGame.Horizontal.ReadValue<float>();
        bool Attack1 = PlayerActionControl.InGame.Attack1.triggered;


        // state checks
        if (!stun)
        {
            // kinetic motion
            if (State.slash != CharacterState && State.dash != CharacterState)
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
        
    }

    void OnTriggerStay(Collider other)
    {
        //Damage From Enemies
        if (other.tag == "Enemy")
        {
            DamagePlayer(other.transform.position);
        }
    }
    private void OnEnable()
    {
        PlayerActionControl.Enable();

    }
    private void OnDisable()
    {
        PlayerActionControl.Disable();
    }

    #endregion

    #region Player Actions
    private void LightSlash()
    {
        if ( CharacterState != State.slash && CharacterState != State.dash || SessionData.ComboCount > 0)
        {
            CharacterState = State.slash;
            rb.velocity = Vector3FromDirectionMagnitude(Direction, 10);
            GameObject Attack = Instantiate(Slash1);
            Attack.transform.position = transform.position + Vector3FromDirectionMagnitude(Direction, 1.5f);
            Attack.transform.rotation = Quaternion.Euler(90, Attack.transform.rotation.y, AngleFromDirection(Direction));
        }
    }

    private void StartDash()
    {
        Invincible = true;
        if (CharacterState != State.slash && CharacterState != State.dash && SessionData.DashUnlocked)
        {
            CharacterState = State.dash;
            rb.useGravity = false;
            rb.velocity = Vector3FromDirectionMagnitude(Direction, SessionData.DashSpeed);
            Invoke("EndDash", .20f);
        }
    }

    private void EndDash()
    {
        rb.useGravity = true;
        Invincible = false;
        CharacterState = State.idle;
        rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0,0,0), .5f);
    }

    private void ResetStun()
    {
        stun = false;
    }

    #endregion

    #region Utility Functions
    private Vector3 Vector3FromDirectionMagnitude(Direction direction, float magnitude)
    {
        Vector3 result = new Vector3(0,0,0);
        switch (direction)
        {
            case Direction.up:
                result = new Vector3(0, 0, magnitude);

                break;
            case Direction.down:
                result = new Vector3(0, 0, -magnitude);
                break;

            case Direction.left:
                result = new Vector3(-magnitude, 0, 0);
                break;

            case Direction.right:
                result = new Vector3(magnitude, 0, 0);
                break;

            case Direction.downleft:
                result = new Vector3(-magnitude * (float)Math.Sqrt(.5), 0, -magnitude * (float)Math.Sqrt(.5));
                break;

            case Direction.downright:
                result = new Vector3(magnitude * (float)Math.Sqrt(.5), 0, -magnitude * (float)Math.Sqrt(.5));
                break;

            case Direction.upleft:
                result = new Vector3(-magnitude * (float)Math.Sqrt(.5), 0, magnitude * (float)Math.Sqrt(.5));
                break;

            case Direction.upright:
                result = new Vector3(magnitude * (float)Math.Sqrt(.5), 0, magnitude * (float)Math.Sqrt(.5));
                break;

        }


        return result;
        
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

    private void DamagePlayer(Vector3 collisionPoint)
    {
        if (!stun)
        {
            stun = true;
            Invoke("ResetStun", .3f);
            rb.velocity = Vector3.MoveTowards(transform.position, collisionPoint, -40) - transform.position;
            SessionData.Health--;
            Debug.Log(SessionData.Health);
        }
    }

    #endregion
}
