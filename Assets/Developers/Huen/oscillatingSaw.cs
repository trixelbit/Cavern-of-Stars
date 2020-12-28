using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class oscillatingSaw : MonoBehaviour
{
    [Header("Dependencies")]
    public Transform posA;
    public Transform posB;

    [Header("Saw Properties")]
    public float speed = 3f;

    [Header("Gizmos Properties")]
    [Range (0,3)]public float sphereSize = 1f;

    public Transform startPos;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
        transform.position = posA.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == posA.position)
        {
            nextPos = posB.position;
        }

        if (transform.position == posB.position)
        {
            nextPos = posA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Vector4 setColor = new Vector4(0,1,0,255);

        //Gizmos
        Gizmos.color = setColor;
        Gizmos.DrawLine(posA.position, posB.position);
        Gizmos.DrawWireSphere(posA.position, sphereSize);
        Gizmos.DrawWireSphere(posB.position, sphereSize);

        //Handles
        Handles.color = setColor;
        Handles.Label(posA.position, "Point A");
        Handles.Label(posB.position, "Point B");
    }
}
