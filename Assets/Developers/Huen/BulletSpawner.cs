using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BulletSpawner : MonoBehaviour
{
    #region Dependencies
    [Header("Dependencies")]
    public GameObject bullet; //references the bullet object
    public Bullet bulletScript;
    #endregion

    #region Variables
    [Header("Bullet Variables")]
    public Vector3 bulletDir;

    [Header("Gizmos and Raycast Variables")]
    public Color setColor;
    [Range(0,3)] public float gizmoSize;
    #endregion

    #region Start, Update
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) { //when the spacebar is pushed
            bulletScript.instantiateBullet();
        }

        Debug.DrawRay(transform.position, bulletDir, setColor);
    }
    #endregion
}
