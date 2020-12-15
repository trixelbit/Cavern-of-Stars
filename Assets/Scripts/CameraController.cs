using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject position;
    public float CameraSpeed = .2f;
    public bool IsRotationLocked = true;

    private bool Transitioning = false;

    void Awake()
    {
        SessionData.Camera = gameObject;
    }


    // Update is called once per frame
    void Update()
    {

        //lerp to position
        

        if (Transitioning)
        {
            transform.position = Vector3.Lerp(transform.position, position.transform.position, Mathf.SmoothStep(0.0f, 1.0f, Mathf.SmoothStep(0.0f, 1.0f, .2f)));

            if (Vector3.Distance(transform.position, position.transform.position) < 2)
            {
                LockCameraRotation();
            }


        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, position.transform.position, CameraSpeed);
        }


        // look at target
        if (!IsRotationLocked)
        {
            // smooth rotation
            //transform.rotation = Quaternion.Slerp(transform.rotation, , .1 * Time.deltaTime);
        }
    }

    public void LockCameraRotation()
    {
        Transitioning = false;
        IsRotationLocked = true;
    }

    // begin camera transition
    public void InvokeLock()
    {
        IsRotationLocked = false;
        Transitioning = true;
    }

}
