using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject CameraTarget;
    public float RotationSpeed = .08f;
    public float MovementSpeed = .2f;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            var cameraController = SessionData.Camera.GetComponent<CameraController>();
            cameraController.InvokeLock(CameraTarget, RotationSpeed, MovementSpeed);

        }
    }
}
