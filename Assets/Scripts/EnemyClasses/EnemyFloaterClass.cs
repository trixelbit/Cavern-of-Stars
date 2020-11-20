using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFloaterClass : BaseEnemyClass
{
    public int HP = 3;
    public GameObject SpritePlane;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckHP();
        OscilateSpritePlane();
    }


    private void OscilateSpritePlane()
    { 
        SpritePlane.transform.position = new Vector3(transform.position.x, .01f * Mathf.Sin(Time.time) + SpritePlane.transform.position.y, transform.position.z);
    }

    private void Faceplayer()
    {

    }



}
