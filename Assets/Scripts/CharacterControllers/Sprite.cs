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

public class Sprite
{

    public Renderer Renderer;
    public Transform ParentTransform;
    public Texture SpriteSheet;
    public Vector3 TransformOrginalScale;
    public float FrameCount = 1;
    public float ImageSpeed = 1;
    public float ImageIndex = 0;
    public bool Loop = true;
    public bool Interuptable = true;
    public bool Completed = false;
    public float OrginalSpriteWidth;
    public float OrginalSpriteHeight;
    public float SpriteWidth;
    public float SpriteHeight;




    public Sprite(Renderer renderer, Texture spriteSheet, Transform transform, float frameCount, float imageSpeed, float imageIndex)
    {
        Renderer = renderer;
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
        ImageIndex = imageIndex;
        ParentTransform = transform;
        TransformOrginalScale = transform.localScale;

        UpdateSprite(spriteSheet, FrameCount, ImageSpeed, true, true);

        



    }


    public Sprite(Renderer renderer, Texture spriteSheet, Transform transform, float frameCount, float imageSpeed, bool loop)
    {
        Renderer = renderer;
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
        ParentTransform = transform;
        TransformOrginalScale = transform.localScale;
        Loop = loop;

        UpdateSprite(spriteSheet, FrameCount, ImageSpeed, true, true);

    }

    public Sprite(Renderer renderer, Texture spriteSheet, Transform transform, float frameCount, float imageSpeed)
    {
        Renderer = renderer;
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
        ParentTransform = transform;
        TransformOrginalScale = transform.localScale;

        UpdateSprite(spriteSheet, FrameCount, ImageSpeed, true, true);

    }

    public Sprite(Renderer renderer, Texture spriteSheet, Transform transform)
    {
        Renderer = renderer;
        ParentTransform = transform;
        TransformOrginalScale = transform.localScale;

        UpdateSprite(spriteSheet, FrameCount, ImageSpeed, true, true);

        OrginalSpriteWidth = Renderer.material.mainTexture.width;
        SpriteWidth = OrginalSpriteWidth;
        OrginalSpriteHeight = Renderer.material.mainTexture.height;
        SpriteHeight = OrginalSpriteHeight;

    }

    public void UpdateSprite(Texture texture, float frameCount, float imageSpeed, bool loop, bool interuptable)
    {
        
        if (texture.name != Renderer.sharedMaterial.mainTexture.name )
        {
            Renderer.material.SetTexture("_MainTex", texture);
            Renderer.material.SetTexture("_EmissionMap", texture);
            SpriteSheet = texture;
            Loop = loop;
            ImageIndex = 0;
            Completed = false;     
            FrameCount = frameCount;
            ImageSpeed = imageSpeed;
            Interuptable = interuptable;
        }
    }


    public void Render()
    {

        float image_xscale = 1 / FrameCount;
        

        

        //resizes material xscale to match width of 1 frame
        Renderer.material.SetTextureScale("_MainTex", new Vector2(image_xscale, 1f));
        Renderer.material.SetTextureScale("_EmissionMap", new Vector2(image_xscale, 1f));


        float SingleFrameWidth = Renderer.material.mainTexture.width / FrameCount;
        float SingleFrameHeight = Renderer.material.mainTexture.height;


        // percentage diff between origanl scale and new scale
        float WidthScaleDifference = SingleFrameWidth / OrginalSpriteWidth;
        float HeightScaleDifference = SingleFrameHeight / OrginalSpriteHeight;


        if (SpriteWidth != SingleFrameWidth && ParentTransform != null)
        {

            
            ParentTransform.localScale = new Vector3(TransformOrginalScale.x * WidthScaleDifference, ParentTransform.localScale.y, TransformOrginalScale.z * HeightScaleDifference);


        }

        SpriteWidth = SingleFrameWidth;
        SpriteHeight = SingleFrameHeight;

        float offset = (float)Math.Floor(ImageIndex) / FrameCount;

        Renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        
        if (Loop || ImageIndex < FrameCount - 1)
        {
            ImageIndex = (ImageIndex + (ImageSpeed * Time.deltaTime)) % FrameCount;
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

    [NamedArrayAttribute (new string[] { "down", "down left", "down right", "left", "right", "up", "up left", "up right"} )]
    public Texture[] SpriteSheets = new Texture[8];

    public OctaSpriteSet(float frameCount, float imageSpeed,  Texture[] spriteSheets)
    {
        FrameCount = frameCount;
        ImageSpeed = imageSpeed;
        SpriteSheets = spriteSheets;
    }
}






