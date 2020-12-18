using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public enum ItemType
    { 
        Key = 0,
        Health = 1
    }

    public ItemType Type;
    public float Value = 1;
    public float HorizontalRotationSpeed = 1;
    public float OscAmplitude = .012f;
    public float OscFrequency = 4;

    public GameObject SpriteQuad;

    private bool Following = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteQuad.transform.position += Vector3.up * OscAmplitude * Mathf.Sin(Time.time * OscFrequency) * Time.deltaTime;
        SpriteQuad.transform.rotation *= Quaternion.AngleAxis( HorizontalRotationSpeed * Time.deltaTime, Vector3.up) ;
        transform.LookAt(SessionData.Camera.transform);

        // item will follow player
        if (Following)
        {
            if (Vector3.Distance(transform.position, SessionData.Player.transform.position) > 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, SessionData.Player.transform.position, .1f);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (Type)
            {
                case ItemType.Key:
                    SessionData.KeyCount += (int)Value;
                    GetComponent<SphereCollider>().enabled = false;
                    Following = true;
                    break;

                case ItemType.Health:
                    break;
            }
        }
    }
}
