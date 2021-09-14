using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*@description: 
*   PlayerAudio class swaps audioclips to match the current player state.
*/
public class PlayerAudio : MonoBehaviour
{
    [Header("Player Movement")]
    public AudioClip Walk;
    public AudioClip Dash;
    public AudioClip[] Slash;
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
                Source.volume = GlobalData.SoundVolume * .2f;
                if (!Source.isPlaying)
                {
                    Source.Play();
                    
                    Source.loop = true;
                }
                break;

            case State.idle:
                Source.volume = 0;
                break;

            case State.slash:

                if (!ElementIsInArray(Source.clip, Slash) || !Source.isPlaying)
                {
                    Source.clip = Slash[(int)Random.Range(0, Slash.Length)];

                    Source.volume = GlobalData.SoundVolume * .5f;
                    Source.loop = false;
                    Source.Play();
                }
                break;


            case State.dash:
                if (!Source.isPlaying || Source.clip != Dash)
                {
                    Source.volume = GlobalData.SoundVolume * .2f; 
                    Source.clip = Dash;
                    Source.loop = false;
                    if (!Source.isPlaying)
                    {
                        Source.Play();
                    }
                
                }
                
                break;

            default:
                Source.Stop();
                break;
        }
    }

    private bool ElementIsInArray(AudioClip e, AudioClip[] arr)
    {
        foreach (AudioClip element in arr)
        {
            if (element == e)
            {
                return true;
            }
        }

        return false;

            
    }

}


