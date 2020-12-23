using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oscillatingSaw : MonoBehaviour
{
    [Header("Saw Variables")]
    public float speed = 3.0f;
    public float sphereSize = 1f;
    public Transform pointAPos, pointBPos;
    public Transform startPos;
    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position == pointAPos.position)
        {
            nextPos = pointBPos.position;
        }

        if (transform.position == pointBPos.position)
        {
            nextPos = pointAPos.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(pointAPos.position, sphereSize);
        Gizmos.DrawWireSphere(pointBPos.position, sphereSize);
        Gizmos.DrawLine(pointAPos.position, pointBPos.position);
    }
}
