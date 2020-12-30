using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Dependencies and Referenced Variables
    [Header("Dependencies and Referenced Variables")]
    public BulletSystem bulletSys; //references the Bullet System Class
    private float bulletSpeed;
    #endregion

    #region Start and Update
    // Start is called before the first frame update
    void Start()
    {
        bulletSpeed = bulletSys.bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * bulletSpeed * Time.deltaTime; //Shoots the bullet off in a random direction
    }
    #endregion
}

