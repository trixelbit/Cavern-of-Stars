using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletSpawner : MonoBehaviour
{
    #region Dependencies
    [Header("Dependencies")]
    public GameObject bullet;
    #endregion

    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { //when the spacebar is pushed
            AttackHell();
        }
    }

    #region Attacks
    public void instantiateBullet()
    {
        //Instantiates the bullet at the init location with no rotation
        Instantiate(bullet.gameObject, transform.position, Quaternion.Euler(0, 0, 0));
    }
    
    public void AttackHell()
    {
        for (int i = 0; i <= 360; i++)
        {
            var temp = Instantiate(bullet);
            temp.GetComponent<Bullet>().UpdateVelocity(new Vector3(0, i, 0), 0.5f);
        }
    }
    #endregion
}
