using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyClass : MonoBehaviour
{ 
    private int HP = 6;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Hit")
        {
            --HP;
        }
    }

    public void CheckHP()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
