using System;
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
    public Sprite Sprite;
    State CharacterState;
    Direction Direction;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        CharacterState = Parent.transform.GetComponent<movement>().CharacterState;
        Direction = Parent.transform.GetComponent<movement>().Direction;
        Sprite = new Sprite(Rend, idle.SpriteSheets[(int)Direction.down], transform);
    }

    void Update()
    {
        CharacterState = Parent.transform.GetComponent<movement>().CharacterState;
        Direction = Parent.transform.GetComponent<movement>().Direction;


        switch (CharacterState)
        {
            case State.idle:
                Sprite.UpdateSprite(idle.SpriteSheets[(int)Direction], idle.FrameCount, idle.ImageSpeed, true, true);
                break;

            case State.running:
                Sprite.UpdateSprite(run.SpriteSheets[(int)Direction], run.FrameCount, run.ImageSpeed, true, true);
                break;
            case State.slash:

                
                if (Sprite.SpriteSheet == slash.SpriteSheets[(int)Direction] && Sprite.Completed)
                {
                    // return back to idle
                    Parent.transform.GetComponent<movement>().CharacterState = State.idle;
                    Sprite.UpdateSprite(idle.SpriteSheets[(int)Direction], idle.FrameCount, idle.ImageSpeed, true, true);
                }
                else
                {
                    Sprite.UpdateSprite(slash.SpriteSheets[(int)Direction], slash.FrameCount, slash.ImageSpeed, false, false);
                }

                break;
        }

        Sprite.Render();
    }


}
