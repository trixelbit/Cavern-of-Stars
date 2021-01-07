using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardToCamera : MonoBehaviour
{
    public Vector3 Offset = new Vector3(0, 180, 0);

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(GlobalData.Camera.transform, -Vector3.up);
        transform.rotation *= Quaternion.Euler(Offset);
    }
}
