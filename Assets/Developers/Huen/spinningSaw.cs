using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinningSaw : MonoBehaviour
{
    [Header("Saw Variables")]
    public float spinSpeed = 300f;
    public bool clockwise = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (clockwise)
        {
            transform.Rotate(Vector3.forward * -spinSpeed * Time.deltaTime);
        }

        if (!clockwise)
        {
            transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);
        }    
    }
}
