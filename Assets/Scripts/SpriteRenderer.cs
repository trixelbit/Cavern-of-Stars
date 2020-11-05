﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpriteRenderer : MonoBehaviour
{
    public GameObject Parent;


    // sprites sets
    public OctaSpriteSet idle;
    public OctaSpriteSet run;
    public OctaSpriteSet dash;
    public OctaSpriteSet slash;

    Renderer Rend;
    Sprite sprite;
    State CharacterState;
    Direction Direction;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        CharacterState = Parent.transform.GetComponent<movement>().CharacterState;
        Direction = Parent.transform.GetComponent<movement>().Direction;
        sprite = new Sprite(Rend, idle.SpriteSheets[(int)Direction.down]);
    }

    void Update()
    {
        CharacterState = Parent.transform.GetComponent<movement>().CharacterState;
        Direction = Parent.transform.GetComponent<movement>().Direction;


        switch (CharacterState)
        {
            case State.idle:
                sprite.UpdateSprite(idle.SpriteSheets[(int)Direction], idle.FrameCount, idle.ImageSpeed, true);
                break;

            case State.running:
                sprite.UpdateSprite(run.SpriteSheets[(int)Direction], run.FrameCount, run.ImageSpeed, true);
                break;
        }
 
        sprite.Render();
    }


}
