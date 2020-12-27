using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class rotatingSaw : MonoBehaviour
{
    [Header("Dependencies")]
    public Transform origin;

    [Header("Saw Properties")]
    public float rotationSpeed = 3f;

    [Header("Gizmos Properties")]
    public float sphereSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnDrawGizmos()
    {
        Vector4 setColor = new Vector4(0, 0, 1, 255);

        //Gizmos
        Gizmos.color = setColor;
        Gizmos.DrawLine(origin.position, transform.position);
        Gizmos.DrawWireSphere(origin.position, sphereSize);

        //Handles
        Handles.color = setColor;
        Handles.Label(origin.position, "Point A");
    }
}
