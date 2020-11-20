using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloaterClass : BaseEnemyClass
{
    public ParticleSystem Haze;

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
        SpritePlane.transform.position = new Vector3(SpritePlane.transform.position.x, .01f * Mathf.Sin(Time.time) + SpritePlane.transform.position.y, SpritePlane.transform.position.z);
    }

    private void LerpBackToPosition()
    {
        SpritePlane.transform.position = Vector3.Lerp( SpritePlane.transform.position, transform.position, .1f);
    }


    private void Faceplayer()
    {

    }

    public override void Death() 
    {
        Debug.Log(" part ded");
        Haze.Stop();
        Haze.transform.parent = null;
        Debug.Log("ded ded");
        Destroy(gameObject);
    }



}
