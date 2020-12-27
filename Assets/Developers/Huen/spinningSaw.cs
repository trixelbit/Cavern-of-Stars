using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningSaw : MonoBehaviour
{
    [Header("Saw Variables")]
    public float spinSpeed = 300f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);    
    }
}
