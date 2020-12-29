using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSystem : MonoBehaviour
{
    #region Dependencies & Variables
    //[Header("Dependencies")]

    [Header("Bullet Variables")]
    public float bulletSpeed = 3f;
    [Range(0.5f,1)] public float bulletLife;

    [Header("Gizmos and Raycast Variables")]
    public Color setColor;
    #endregion

    #region Private Variables
    private Vector3 bulletDir;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnDrawGizmos()
    {
        
    }
}
