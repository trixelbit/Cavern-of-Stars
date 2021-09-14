using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{
    public TextAsset ConversationFile;

    [Header("Character Portraits")]
    public UnityEngine.Sprite Nin;
    public UnityEngine.Sprite Deya;

    [Header("Sound Effects")]
    public AudioClip[] TextTik;

    // Current Dialogue
    private Dialogue Convo;
    private int ConvoIndex;
    private string DialogueText;
    private string SpeakerName;

    // Component References
    private TextMeshProUGUI TextMesh;
    private UnityEngine.UI.Image CharacterPortrait;
    private TextMeshProUGUI SpeakerTextMesh;

    void Awake()
    {
        GameObject child;
        child = GlobalData.Canvas.transform.GetChild(2).gameObject;
        TextMesh = child.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        CharacterPortrait = child.transform.GetChild(2).GetComponent<Image>();
        SpeakerTextMesh = child.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!GlobalData.ChatBoxIsActive)
            {
                GlobalData.ChatBoxIsActive = true;
                BeginDialogue(ConversationFile);
            }
            else
            {
                NextDialogue();
            }
            

        }
    }

    public void BeginDialogue(TextAsset JsonFile)
    {
        // Load Conversation from JSON File
        ConvoIndex = 0;
        Convo = JsonUtility.FromJson<Dialogue>(JsonFile.text);
        GlobalData.Locked = true;

        UpdateCharacter(Convo.Conversation[ConvoIndex].SpeakerName);
        DialogueText = Convo.Conversation[ConvoIndex].Text;
        StartCoroutine("AddText");
    }

    public void NextDialogue()
    {
        if (ConvoIndex + 1 >= Convo.Conversation.Length)
        {
            // end conversation
            GlobalData.ChatBoxIsActive = false;
            GlobalData.Locked = false;

        }
        else
        {
            // load next dialogue 
            ConvoIndex++;
            UpdateCharacter(Convo.Conversation[ConvoIndex].SpeakerName);
            DialogueText = Convo.Conversation[ConvoIndex].Text;
            StartCoroutine("AddText");
        }
    }

    // Animate Text Popping In to the Dialious Box
    IEnumerator AddText()
    {
        string buffer = "";
        int index = 0;

        while ('|' != DialogueText[index])
        {

            if (DialogueText[index] != '.' && DialogueText[index] != ' ')
            {
                AudioSource Source = GlobalData.Canvas.GetComponent<AudioSource>();

                Source.clip = TextTik[(int)Random.Range(0, TextTik.Length)];
                Source.volume = GlobalData.SoundVolume * .5f;
                Source.loop = false;
                Source.Play();
            }
            

            buffer += DialogueText[index];
            TextMesh.text = buffer;
            index++;

            yield return new WaitForSeconds(Convo.Conversation[ConvoIndex].CharDelay);
        }
    }


    public void UpdateCharacter(string speakerName)
    {
        SpeakerTextMesh.text = speakerName + ":";
        switch (speakerName)
        {
            case "Nin":
                CharacterPortrait.sprite = Nin;
                CharacterPortrait.rectTransform.sizeDelta = new Vector2(Nin.texture.width, Nin.texture.height);
                break;

            case "Deya":
                CharacterPortrait.sprite = Deya;
                CharacterPortrait.rectTransform.sizeDelta = new Vector2(Deya.texture.width, Deya.texture.height);
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


[System.Serializable]
public class Dialogue
{
    public Quote[] Conversation;
}

[System.Serializable]
public class Quote
{
    public string SpeakerName;
    public string Text;
    public float CharDelay;
}





