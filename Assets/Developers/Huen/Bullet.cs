using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables
    [Header("Bullet Variables")]
    [Range(0,1000)] public float bulletSpeed = 5f;
    [Range(0,5)] public float bulletLife = 1f;
    public Vector3 bulletDir;
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += bulletDir * bulletSpeed * Time.deltaTime;
    }

    public void instantiateBullet()
    {
        GameObject clone = Instantiate(this.gameObject, transform.position, Quaternion.Euler(0, 0, 0)); //Instantiates the bullet at the init location with no rotation
        clone.transform.LookAt(Camera.main.transform.position, -Vector3.up);
        Destroy(clone, bulletLife);
    }
}
