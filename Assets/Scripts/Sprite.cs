using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprite
{
    // Start is called before the first frame update
    public Renderer Renderer;
    public Material SpriteMaterial;
    public float FrameCount;
    public float ImageSpeed;
    public bool Loop;

    public Sprite(Renderer renderer, float frameCount, float imageSpeed)
    {
        Renderer = renderer;
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
    }

    public void UpdateSprite(Material spriteMaterial, float frameCount, float imageSpeed)
    {
        Renderer.material = spriteMaterial;
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
    }


    public void Render()
    {
        float image_xscale = 1 / FrameCount;

        Renderer.material.SetTextureScale("_MainTex", new Vector2(image_xscale, 1f));

        float offset = ((float)Math.Floor(Time.time * ImageSpeed) % FrameCount) * (1 / FrameCount);

        Renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}


[Serializable]
public class OctaSpriteSet
{
    
    public float FrameCount;
    public float ImageSpeed;
    public Material Down;
    public Material DownRight;
    public Material Right;
    public Material UpRight;
    public Material Up;
    public Material UpLeft;
    public Material Left;
    public Material Downleft;

    public OctaSpriteSet(float frameCount, float imageSpeed,  Material[] spriteMaterials)
    {
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
        Down = spriteMaterials[0];
        DownRight = spriteMaterials[1];
        Right = spriteMaterials[2];
        UpRight = spriteMaterials[3];
        Up = spriteMaterials[4];
        UpLeft = spriteMaterials[5];
        Left = spriteMaterials[6];
        Downleft = spriteMaterials[7];

    }
}






