﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Public Variables
    [Header("Bullet Variables")]
    [Range(0,1000)] public float Speed = 5f;
    [Range(0,5)] public float LifeSpan = 1f;
    public Vector3 Rotation;
    #endregion

    #region Orient the bullet and move it.

    private void Start()
    {
        transform.rotation = Quaternion.Euler(Rotation);
    }

    // Update is called once per frame
    void Update()
    {
        // move with given velocity
        transform.Translate(Vector3.forward * Speed);
        Destroy(gameObject, LifeSpan);
    }
    #endregion

    #region Additional Flexibility
    public void UpdateVelocity(Vector3 rotation, float speed)
    {
        // update the values for speed and rotation
        transform.rotation = Quaternion.Euler(rotation);
        Speed = speed;
        Rotation = rotation;
    }
    #endregion

    #region Trigger Collision with Player Destroy
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        if (other.tag == "player")
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
