using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedGateTrigger : MonoBehaviour
{
    public bool Locked = true;
    public float MovementSpeed = .1f;
    public float ShakeAmount = .1f;
    public float SinkDistance = 10;

    private Vector3 InitialPosition;


    private void Awake()
    {
        InitialPosition = transform.position;
    }



    // Update is called once per frame
    void Update()
    {
        if (!Locked)
        {
            if (Vector3.Distance(transform.position, InitialPosition) < SinkDistance )
            {
                transform.position += Vector3.down * MovementSpeed;
                Vector3 Offset = new Vector3( InitialPosition.x + Random.Range( -ShakeAmount, ShakeAmount), transform.position.y, InitialPosition.z + Random.Range( -ShakeAmount, ShakeAmount));
                transform.position = Vector3.Lerp(transform.position, Offset, .1f);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3.down * SinkDistance));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (GlobalData.KeyCount > 0 && Locked)
            {
                GlobalData.KeyCount--;
                Locked = false;
            }
        }
    }
}
