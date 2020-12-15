using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject position;
    public GameObject position1;
    public GameObject position2;
    public float CameraSpeed = .2f;
    public bool IsRotationLocked = true;


    void Awake()
    {
        SessionData.Camera = gameObject;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            position = position1;
            InvokeLock();
        }

        
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            position = position2;
            InvokeLock();
        }

        //lerp to position
        transform.position = Vector3.Lerp( transform.position, position.transform.position, CameraSpeed );

        // look at target
        if (!IsRotationLocked)
        {
            transform.LookAt(target.transform);
        }
    }

    public void LockCameraRotation()
    {
        IsRotationLocked = true;
    }

    public void InvokeLock()
    {
        IsRotationLocked = false;
        Invoke("LockCameraRotation", .5f);
    }

}
