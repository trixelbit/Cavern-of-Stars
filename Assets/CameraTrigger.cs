using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject CameraTarget;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            SessionData.Camera.GetComponent<CameraController>().position = CameraTarget;
            SessionData.Camera.GetComponent<CameraController>().InvokeLock();
        }
    }
}
