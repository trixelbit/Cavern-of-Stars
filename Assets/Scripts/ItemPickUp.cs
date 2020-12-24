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
    public GameObject Target;

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
        transform.LookAt(GlobalData.Camera.transform);

        // item will follow player
        if (Following && Target != null)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > 3)
            {
                //transform.position = Vector3.MoveTowards(transform.position, SessionData.Player.transform.position, .1f);
                transform.position = Vector3.Slerp(transform.position, Target.transform.position, .02f);
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
                    GlobalData.KeyCount += (int)Value;
                    //GetComponent<SphereCollider>().enabled = false;
                    //Following = true;
                    //Target = SessionData.Player;
                    DestroyItem();
                    break;

                case ItemType.Health:
                    break;
            }
        }
    }


    public void DestroyItem()
    {
        Destroy(gameObject);
    }


}
