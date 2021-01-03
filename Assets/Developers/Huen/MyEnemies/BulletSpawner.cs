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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            InstantiateBullet();
        }
    }

    #region Attacks
    public void InstantiateBullet()
    {
        //Instantiates the bullet at the init location with no rotation
        var bul = Instantiate(bullet, transform.position, Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z));
        bul.GetComponent<Bullet>().UpdateVelocity(new Vector3(transform.position.x, transform.position.y, transform.position.z), default);
    }
    
    public void AttackHell()
    {
        for (int i = 0; i <= 360; i += 20)
        {
            var temp = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,0));
            temp.GetComponent<Bullet>().UpdateVelocity(new Vector3(0, i, 0), 0.5f);
        }
    }
    #endregion
}
