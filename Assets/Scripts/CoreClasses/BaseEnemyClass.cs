using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyClass : MonoBehaviour
{ 
    public int HP = 6;
    public int KnockBackValue = 1;


    public AudioClip SoundHurt;

    public GameObject SpritePlane;
    public GameObject HitVFX;

   


    private void OnTriggerEnter(Collider collision)
    {
        // collision with damaging object
        if (collision.tag == "Hit")
        {
            RecieveDamage(1);
        }
    }

    public void RecieveDamage(int damageDelt)
    {
        GameObject VFX = Instantiate(HitVFX);
        VFX.transform.position = transform.position;
        HP -= damageDelt;
        SpritePlane.transform.position += new Vector3(Random.Range(-KnockBackValue, KnockBackValue), Random.Range(-KnockBackValue, KnockBackValue), Random.Range(-KnockBackValue, KnockBackValue));
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
