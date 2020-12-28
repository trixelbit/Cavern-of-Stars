﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject position;
    public float MovementSpeed = .2f;
    public float RotationSpeed = .08f;
    public bool IsRotationLocked = true;

    private bool Transitioning = false;

    void Awake()
    {
        GlobalData.Camera = gameObject;
    }


    // Update is called once per frame
    void Update()
    {

        //lerp to position
        

        if (Transitioning)
        {
            transform.position = Vector3.Lerp(transform.position, position.transform.position, Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, .2f)));

            if (Vector3.Distance(transform.position, position.transform.position) < 1)
            {
                LockCameraRotation();
            }
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, position.transform.position, Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, MovementSpeed)));
            //transform.position = Vector3.Lerp(transform.position, position.transform.position, MovementSpeed);
        }

        // look at target
        if (!IsRotationLocked)
        {
            // smooth rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(GlobalData.Player.transform.position - transform.position), RotationSpeed );
        }
    }

    public void LockCameraRotation()
    {
        Transitioning = false;
        IsRotationLocked = true;
    }

    // begin camera transition
    public void InvokeLock(GameObject target, float rotationSpeed, float movementSpeed)
    {
        position = target;
        RotationSpeed = rotationSpeed;
        MovementSpeed = movementSpeed;
        IsRotationLocked = false;
        Transitioning = true;
    }

}
