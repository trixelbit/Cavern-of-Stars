using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyClass : MonoBehaviour
{ 
    private int HP = 6;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Hit")
        {
            --HP;
        }
    }

}
