using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class rotatingSaw : MonoBehaviour
{
    [Header("Gizmos Properties")]
    [Range (0,3)]public float sphereSize = 1f;


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
        Gizmos.DrawLine(transform.position, transform.position);
        Gizmos.DrawWireSphere(transform.position, sphereSize);

        //Handles
        Handles.color = setColor;
        Handles.Label(transform.position, "Origin");
    }
}
