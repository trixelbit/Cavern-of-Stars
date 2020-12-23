using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatingSaw : MonoBehaviour
{
    [Header("Saw Variables")]
    public float rotateSpeed = 3.0f;
    public float sphereSize;
    public Transform pointOrigin;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x + rotateSpeed, 0, 0);
        //transform.RotateAround(new Vector3(0f,0f,0f), new Vector3(1f,0f,0f),90f * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pointOrigin.position, sphereSize);
        Gizmos.DrawLine(transform.position, pointOrigin.position);
    }
}
