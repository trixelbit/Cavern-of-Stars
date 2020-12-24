using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{

    public enum CameraType
    { 
        Topdown = 0,
        SideView = 1,
        Other = 2
    }


    public GameObject CameraTarget;
    public float RotationSpeed = .08f;
    public float MovementSpeed = .2f;
    public CameraType camType = CameraType.SideView;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            var cameraController = GlobalData.Camera.GetComponent<CameraController>();
            
            switch(camType)
            {
                case CameraType.SideView:
                    cameraController.InvokeLock(GlobalData.Player.transform.GetChild(1).gameObject, RotationSpeed, MovementSpeed);
                    break;

                case CameraType.Topdown:
                    cameraController.InvokeLock(GlobalData.Player.transform.GetChild(0).gameObject, RotationSpeed, MovementSpeed);
                    break;

                default:
                    cameraController.InvokeLock(CameraTarget, RotationSpeed, MovementSpeed);
                    break;
            }
        }
    }
}
