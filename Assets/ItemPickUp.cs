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

    public GameObject SpriteQuad;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpriteQuad.transform.position += Vector3.up * .01f * Mathf.Sin(Time.time * 3);
        SpriteQuad.transform.rotation *= Quaternion.AngleAxis( HorizontalRotationSpeed , Vector3.up);
        transform.LookAt(SessionData.Camera.transform);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            switch (Type)
            {
                case ItemType.Key:
                    SessionData.KeyCount += (int)Value;
                    Destroy(gameObject);
                    break;

                case ItemType.Health:
                    break;
            }
        }
    }
}
