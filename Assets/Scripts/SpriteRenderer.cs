using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteRenderer : MonoBehaviour
{
    public GameObject Parent;


    // sprites
    public float idle_framecount = 1;
    public float idle_speed;


    public OctaSpriteSet idle;
    public OctaSpriteSet run;

    Renderer rend;
    Sprite sprite;
    State playerState;
    Direction direction;

    void Start()
    {


        rend = GetComponent<Renderer>();
        playerState = Parent.transform.GetComponent<movement>().playerState;
        direction = Parent.transform.GetComponent<movement>().runDirection;
        sprite = new Sprite(rend, 1, 1);


    }

    void Update()
    {
        playerState = Parent.transform.GetComponent<movement>().playerState;

        if (playerState == State.idle)
        {
            //sprite.ImageSpeed = run_speed;
            sprite.FrameCount = 1;


        }
        else if (playerState == State.running)
        {

            //sprite.UpdateSprite(run);

    
        }

        sprite.Render();




    }




    void RenderAnimatedSprite( float frame_count, float speed)
    {
        float image_xscale = 1 / frame_count;

        rend.material.SetTextureScale("_MainTex", new Vector2(image_xscale, 1f));
        
        float offset = ((float)Math.Floor(Time.time * speed) % frame_count) * (1 / frame_count);

        rend.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

    public void ShowArrayProperty(SerializedProperty list)
    {
        EditorGUILayout.PropertyField(list);

        EditorGUI.indentLevel += 1;
        for (int i = 0; i < 8; i++)
        {
            Direction a = (Direction)i;
            EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i),
            new GUIContent( a.ToString() ));
        }
        EditorGUI.indentLevel -= 1;
    }


}
