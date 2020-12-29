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
        if (Vector3.Distance(transform.position, GlobalData.Player.transform.position) < 30)
        {
            FloaterMovement();
            Faceplayer();
        }
        
        CheckHP();
        OscilateSpritePlane();
        LerpBackToPosition();
    }


    private void OscilateSpritePlane()
    {
        SpritePlane.transform.position = new Vector3(SpritePlane.transform.position.x, .5f * Mathf.Sin(Time.time * 3) + transform.position.y + .5f, SpritePlane.transform.position.z);
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
        int flip = 1;
        
        if (GlobalData.Player.transform.position.x > transform.position.x)
        {
            flip = 1;
        }
        else
        {
            flip = -1;
        }

        SpritePlane.transform.localScale = new Vector3(Mathf.Abs(SpritePlane.transform.localScale.x) * flip, SpritePlane.transform.transform.localScale.y, SpritePlane.transform.localScale.z);
    }

    public override void Death() 
    {
        GlobalData.EnemyCount--;
        Haze.GetComponent<ParticleSystem>().Stop();
        Haze.transform.parent = null;
        Destroy(Haze, 5);
        Destroy(gameObject);

    }

    public Vector3 Vector3Differenece(Vector3 a, Vector3 b)
    {
        return a - b;
    }

    public void FloaterMovement()
    {
        transform.position = Vector3.MoveTowards( transform.position, GlobalData.Player.transform.position,.01f);

    }




}
