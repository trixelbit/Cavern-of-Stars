using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyClass : MonoBehaviour
{ 
    private int HP = 6;
    public GameObject SpritePlane;
    public int KnockBackValue = 1;


    private void OnTriggerEnter(Collider collision)
    {
        // collision with damaging object
        if (collision.tag == "Hit")
        {
            --HP;
            SpritePlane.transform.position += new Vector3(Random.Range(-KnockBackValue, KnockBackValue), Random.Range(-KnockBackValue, KnockBackValue), Random.Range(-KnockBackValue, KnockBackValue));
        }
    }

    public void CheckHP()
    {
        if (HP <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {
        Destroy(gameObject);
    }

}
