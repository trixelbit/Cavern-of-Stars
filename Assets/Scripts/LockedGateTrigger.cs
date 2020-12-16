using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedGateTrigger : MonoBehaviour
{
    public bool Locked = true;
    public float MovementSpeed = .1f;
    public float ShakeAmount = .1f;

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
            if (Vector3.Distance(transform.position, InitialPosition) < 10 )
            {
                transform.position += Vector3.down * MovementSpeed;
                Vector3 Offset = new Vector3( InitialPosition.x + Random.Range( -ShakeAmount, ShakeAmount), transform.position.y, InitialPosition.z + Random.Range( -ShakeAmount, ShakeAmount));
                transform.position = Vector3.Lerp(transform.position, Offset, .1f);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (SessionData.KeyCount > 0 && Locked)
            {
                SessionData.KeyCount--;
                Locked = false;
            }
        }
    }
}
