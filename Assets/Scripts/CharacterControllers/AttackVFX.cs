using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackVFX : MonoBehaviour
{
    public GameObject SpritePlane;
    public Texture SpriteSheet;
    public float FrameCount;
    public float ImageSpeed;
    [VectorLabels("First Frame", "Last Frame")]
    public Vector2 ActiveFrames;
    
    public Sprite Sprite;
    public float DamageValue = 0;
    public Vector3 InitialVelocity = new Vector3(0,0,0);
    
    [HideInInspector]
    public Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = SpritePlane.GetComponent<Renderer>();
        Sprite = new Sprite(rend, SpriteSheet, SpritePlane.GetComponent<Transform>(), FrameCount, ImageSpeed, false, ActiveFrames);
        GetComponent<Rigidbody>().velocity = InitialVelocity;   
    }

    // Update is called once per frame
    void Update()
    {
        // activate hitbox on active frames of animation;
        GetComponent<CapsuleCollider>().enabled = Sprite.Active;


        //delete on animation completion
        if (SpritePlane != null)
        {

            if (Sprite.Completed)
            {
                //Sprite.ParentTransform = null;
                Destroy(SpritePlane);
                Destroy(this.gameObject);

            }

            Sprite.Render();
        }
    }
}
