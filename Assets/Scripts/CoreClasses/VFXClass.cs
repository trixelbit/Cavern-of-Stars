using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXClass : MonoBehaviour
{
    public GameObject SpritePlane;
    public Texture SpriteSheet;
    public float FrameCount;
    public float ImageSpeed;
    public bool Billboard = true;

    public Sprite Sprite;
    public Vector3 InitialVelocity = new Vector3(0, 0, 0);
    public bool DeleteOnComplete = true;

    [HideInInspector]
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = SpritePlane.GetComponent<Renderer>();
        Sprite = new Sprite(rend, SpriteSheet, SpritePlane.GetComponent<Transform>(), FrameCount, ImageSpeed, !DeleteOnComplete);
        GetComponent<Rigidbody>().velocity = InitialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (Billboard)
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation *= Quaternion.Euler(180, 0, 90);
        }
        
        if (SpritePlane != null)
        {
            if (Sprite.Completed && DeleteOnComplete)
            {
                //Sprite.ParentTransform = null;
                Destroy(SpritePlane);
                Destroy(this.gameObject);
            }

            Sprite.Render();
        }
    }
}
