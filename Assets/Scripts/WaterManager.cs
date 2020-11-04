using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterManager : MonoBehaviour
{

    public GameObject WaterObject;
    public int maxWaterCount = 5;


    private List<GameObject> WaterList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject temp;
        // populate
        for (int i = 0; i < maxWaterCount; i++)
        {
            temp = Instantiate(WaterObject);
            temp.transform.position = transform.position;
            WaterList.Add( temp );
        }


    }

    // Update is called once per frame
    void Update()
    {
        PositionWaterDrops(.05f, 2, 0);//Time.time * .3f);   
    }

    void PositionWaterDrops(float LerpSpeed, float radius, float angle_offset)
    {
        Vector3 target;

        for (int i = 0; i < WaterList.Count; i++)
        {
            float angle = (i + 1) * 360 / (float)WaterList.Count;
            target = new Vector3(getXComponent(angle + angle_offset, radius), 0, getZComponent(angle + angle_offset, radius));

            WaterList[i].transform.position = Vector3.Lerp
                (
                    WaterList[i].transform.position,
                    transform.position + target,
                    LerpSpeed
                );
        }
    }

    float getXComponent(float angle, float radius)
    {
        float a = 0;
        // wrap angle input
        a = wrap(angle, 0, 360);


        // store sign of x components based on angle
        float sign = ( a <= 90 && a >= 0 ) || (a >= 270 && a <= 360) ? 1 : -1;

        // get magnitude of x component
        return sign * radius * (float)Math.Cos(angle); 
    }

    float getZComponent(float angle, float radius)
    {
        float a = 0;
        // wrap angle input
        a = wrap(angle, 0, 360);

        // store sign of x components based on angle
        float sign = (a >= 0 && a <= 180) ? 1 : -1;

        // get magnitude of x component
        return sign * radius * (float)Math.Sin(angle);
    }


    float wrap(float VALUE, float MIN, float MAX)
    {
        float temp;
        if (VALUE < 0)
        {
            temp = MAX - (Math.Abs(VALUE) % MAX);
        }
        else
        {
            temp = VALUE;
        }

        return  (temp - MIN) % (MAX - MIN) + MIN;

    }


}
