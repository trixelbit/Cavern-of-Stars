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
    Sprite sprite;
    State CharacterState;
    Direction direction;

    void Start()
    {
        Rend = GetComponent<Renderer>();
        CharacterState = Parent.transform.GetComponent<movement>().CharacterState;
        direction = Parent.transform.GetComponent<movement>().Direction;
        sprite = new Sprite(Rend, 1, 1);
    }

    void Update()
    {
        CharacterState = Parent.transform.GetComponent<movement>().CharacterState;

        if (CharacterState == State.idle)
        {
            sprite.UpdateSprite(idle.SpriteMaterials[(int)direction], idle.FrameCount, idle.ImageSpeed);

        }
        else if (CharacterState == State.running)
        {

            sprite.UpdateSprite(run.SpriteMaterials[(int)direction], run.FrameCount, run.ImageSpeed );

        }
        sprite.Render();
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
