using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpriteState
{ 
    StartUp = 0,
    Active = 1,
    CoolDown = 2
}

public class Sprite //: MonoBehaviour
{
    // Start is called before the first frame update
    public Renderer Renderer;
    public Texture SpriteSheet;
    public float FrameCount = 1;
    public float ImageSpeed = 1;
    public float ImageIndex = 0;
    public bool Loop = true;
    public bool Completed = false;




    public Sprite(Renderer renderer, Texture spriteSheet, float frameCount, float imageSpeed, float imageIndex)
    {
        Renderer = renderer;
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
        ImageIndex = imageIndex;

        UpdateSprite(spriteSheet, FrameCount, ImageSpeed, true);

    }
    public Sprite(Renderer renderer, Texture spriteSheet, float frameCount, float imageSpeed)
    {
        Renderer = renderer;
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;

        UpdateSprite(spriteSheet, FrameCount, ImageSpeed, true);
    }

    public Sprite(Renderer renderer, Texture spriteSheet)
    {
        Renderer = renderer;

        UpdateSprite(spriteSheet, FrameCount, ImageSpeed, true);
    }

    public void UpdateSprite(Texture texture, float frameCount, float imageSpeed, bool loop)
    {
        
        if (texture.name != Renderer.sharedMaterial.mainTexture.name )
        {
            Renderer.material.SetTexture("_MainTex", texture);
            Loop = loop;
            ImageIndex = 0;
            Completed = false;     
            FrameCount = frameCount;
            ImageSpeed = imageSpeed;
        }
    }


    public void Render()
    {

        float image_xscale = 1 / FrameCount;

        //resizes material xscale to match width of 1 frame
        Renderer.material.SetTextureScale("_MainTex", new Vector2(image_xscale, 1f));


        float offset = (float)Math.Floor(ImageIndex) / FrameCount;

        Renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        
        if (Loop || ImageIndex < FrameCount - 1)
        {
            ImageIndex = (ImageIndex + (ImageSpeed * Time.deltaTime)) % FrameCount;
            //Debug.Log(ImageIndex);
        }
        else 
        {
            ImageIndex = FrameCount - 1;
            Completed = true;
            
        }


    }
}


[Serializable]
public class OctaSpriteSet
{
    
    public float FrameCount;
    public float ImageSpeed;
    public Texture[] SpriteSheets = new Texture[8];

    public OctaSpriteSet(float frameCount, float imageSpeed,  Texture[] spriteSheets)
    {
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
        SpriteSheets = spriteSheets;
    }
}






