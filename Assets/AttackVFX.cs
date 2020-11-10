using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    public GameObject SpritePlane;
    public Texture SpriteSheet;
    public float FrameCount;
    public float ImageSpeed;
    
    public Sprite Sprite;
    public float DamageValue = 0;
    public Vector3 InitialVelocity = new Vector3(0,0,0);
    
    [HideInInspector]
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = SpritePlane.GetComponent<Renderer>();
        Sprite = new Sprite(rend, SpriteSheet, SpritePlane.GetComponent<Transform>(), FrameCount, ImageSpeed, false);
        GetComponent<Rigidbody>().velocity = InitialVelocity;   
    }

    // Update is called once per frame
    void Update()
    {
        if (SpritePlane != null)
        {
            Sprite.Render();

            if (Sprite.Completed)
            {
                Destroy(SpritePlane);
                Destroy(this.gameObject);

            }
        }
    }
}
