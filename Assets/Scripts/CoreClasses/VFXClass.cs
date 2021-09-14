using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXClass : MonoBehaviour
{
    [Header("Sprite")]
    public GameObject SpritePlane;
    public Texture SpriteSheet;
    public float FrameCount;
    public float ImageSpeed;
    public bool Billboard = true;
    public Sprite Sprite;
    public Vector3 RandomOffset;


    [Header("RigidBody")]
    public bool UseRigidbody = true;
    public Vector3 InitialVelocity = new Vector3(0, 0, 0);
    public bool DeleteOnComplete = true;

    [HideInInspector]
    public Renderer rend;


    private Vector3 RotationOffset;
    private Vector3 VelocityBuffer;

    // Start is called before the first frame update
    void Start()
    {
        rend = SpritePlane.GetComponent<Renderer>();
        Sprite = new Sprite(rend, SpriteSheet, SpritePlane.GetComponent<Transform>(), FrameCount, ImageSpeed, !DeleteOnComplete);
        RotationOffset = new Vector3((RandomOffset.x * Random.Range(0, 359)), (RandomOffset.y * Random.Range(0, 359)), (RandomOffset.z * Random.Range(0, 359)));

        if (UseRigidbody)
        {
            GetComponent<Rigidbody>().velocity = InitialVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.Locked)
        {
            

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

        if (Billboard)
        {
            transform.LookAt(Camera.main.transform);
            transform.rotation *= Quaternion.Euler(180 + RotationOffset.x, 0 + RotationOffset.y, 90 + RotationOffset.z);
        }
    }
}
