using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    public GameObject position;
    public float CameraSpeed = .2f;
    private Vector3 Offset, TargetPosition;


    void Awake()
    {
        SessionData.Camera = gameObject;
    }

    void Start()
    {
        Offset = new Vector3(
            -target.transform.position.x + transform.position.x,
            -target.transform.position.y + transform.position.y,
            -target.transform.position.z + transform.position.z);
        

    }

    // Update is called once per frame
    void Update()
    {
        TargetPosition = Offset + target.transform.position;
        transform.position = Vector3.Lerp( transform.position, TargetPosition, CameraSpeed );
    }
}
