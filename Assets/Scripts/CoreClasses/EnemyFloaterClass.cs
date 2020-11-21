using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloaterClass : BaseEnemyClass
{
    public GameObject Haze;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckHP();
        OscilateSpritePlane();
        LerpBackToPosition();
    }


    private void OscilateSpritePlane()
    {
        SpritePlane.transform.position = new Vector3(SpritePlane.transform.position.x, .5f * Mathf.Sin(Time.time) + transform.position.y, SpritePlane.transform.position.z);
    }

    private void LerpBackToPosition()
    {
        if (Mathf.Abs(Vector3Differenece(transform.position, SpritePlane.transform.position).magnitude) > .5f)
        {
            SpritePlane.transform.position = Vector3.Lerp(SpritePlane.transform.position, transform.position, .1f);
        }
        
    }


    private void Faceplayer()
    {

    }

    public override void Death() 
    {
        Debug.Log(" part ded");
        Haze.GetComponent<ParticleSystem>().Stop();
        Haze.transform.parent = null;
        Destroy(Haze, 5);
        Destroy(gameObject);
        Debug.Log("ded ded");
    }

    public Vector3 Vector3Differenece(Vector3 a, Vector3 b)
    {
        return a - b;
    }

    public void FloaterMovement()
    {
        
    }




}
