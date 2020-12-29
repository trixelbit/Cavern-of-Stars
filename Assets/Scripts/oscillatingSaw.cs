using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class oscillatingSaw : MonoBehaviour
{
    #region Public 
    [Header("Dependencies")]
    public Transform posA;
    public Transform posB;
    public bool IsAStartingPoint = true;

    [Header("Saw Properties")]
    public float speed = 3f;

    [Header("Gizmos Properties")]
    [Range (0,3)]public float sphereSize = 1f;


    [Header("Gizmos Properties")]
    public Color SawPathColor;
    public Color LineColor;
    public Transform LinePointA;
    public Transform LinePointB;
    #endregion

    private Vector3 nextPos;
    private LineRenderer LineRend;

    // Start is called before the first frame update
    void Awake()
    {
        LineRend = GetComponent<LineRenderer>();
        LineRend.startColor = Color.black;
        LineRend.endColor = Color.black;
    }

    
    void Start()
    {
        Vector3[] LinePositions = { LinePointA.position, LinePointB.position };
        LineRend.SetPositions(LinePositions);
        nextPos = IsAStartingPoint? posA.position : posB.position; //startPos.position;
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
        Gizmos.color = SawPathColor;
        Gizmos.DrawLine(posA.position, posB.position);
        Gizmos.DrawWireSphere(posA.position, sphereSize);
        Gizmos.DrawWireSphere(posB.position, sphereSize);

        
        Gizmos.color = LineColor;
        Gizmos.DrawLine(LinePointA.position, LinePointB.position);
        Gizmos.DrawWireSphere(LinePointA.position, sphereSize);
        Gizmos.DrawWireSphere(LinePointB.position, sphereSize);

        //Handles
        Handles.color = setColor;
        Handles.Label(posA.position, "Point A");
        Handles.Label(posB.position, "Point B");
    }
}
