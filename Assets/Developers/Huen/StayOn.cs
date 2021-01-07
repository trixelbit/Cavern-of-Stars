using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayOn : MonoBehaviour
{
    public Transform bullet;
    void Update()
    {
        transform.position = bullet.transform.position; 
    }
}
