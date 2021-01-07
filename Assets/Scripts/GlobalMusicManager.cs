using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicManager : MonoBehaviour
{
    public bool On = false;
    public float FadeSpeed = .2f;

    [Header("Global Music")]
    public AudioClip Shop;
    public AudioClip CampFire;

    [Header("Forest Music")]

    [Header("Cavern Music")]

    [Header("City Music")]

    [Header("Castle Music")]

    private AudioSource Source;


    public void Awake()
    {
        GlobalData.GlobalMusicManager = gameObject;
        Source = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (On)
        {
            Source.volume = Mathf.Lerp(Source.volume, 1, FadeSpeed);
        }
        else 
        {
            Source.volume = Mathf.Lerp(Source.volume, 0, FadeSpeed);
        }
    }
}
