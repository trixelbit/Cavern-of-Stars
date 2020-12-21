using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    public bool Visible = false;
    public float TransitionSpeed = 10;
    private Image image;

    // Start is called before the first frame update
    void Awake()
    {
        image = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float alpha =  image.color.a;

        if (Visible)
        {
            alpha = image.color.a < 1 - TransitionSpeed ? image.color.a + TransitionSpeed : 1f;
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, alpha);
        }
        else
        {
            alpha = image.color.a > TransitionSpeed ? image.color.a - TransitionSpeed : 0f;
            image.color = new Vector4(image.color.r, image.color.g, image.color.b, alpha);
        }
    }
}
