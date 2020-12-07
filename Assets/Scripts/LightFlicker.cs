using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public float FlickerRange = .2f;
    public float UpdateFrequency = .2f;
    private float OrginalIntensity;
    // Start is called before the first frame update
    void Start()
    {
        OrginalIntensity = GetComponent<Light>().intensity;
        Invoke("UpdateLightIntensity", UpdateFrequency);

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void UpdateLightIntensity()
    {
        GetComponent<Light>().intensity = Random.Range(OrginalIntensity - FlickerRange, OrginalIntensity + FlickerRange);
        Invoke("UpdateLightIntensity", UpdateFrequency);
    }

}
