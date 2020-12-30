using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [Header("Player Movement")]
    public AudioClip Walk;
    public AudioClip Dash;
    public AudioClip Slash;
    public AudioClip Hurt;
    public AudioClip Death;

    public AudioClip[] SlashVocals;

    private AudioSource Source;
    private State CharacterState;



    private void Awake()
    {
        Source = GetComponent<AudioSource>();
        CharacterState = GetComponent<movement>().CharacterState;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterState = GetComponent<movement>().CharacterState;

        switch (CharacterState)
        {
            case State.running:

                Source.clip = Walk;

                if (!Source.isPlaying)
                {
                    Source.Play();
                }
                break;

            case State.idle:
                Source.Stop();
                break;

            case State.slash:

                break;

            default:
                Source.Stop();
                break;
        }
    }
}


