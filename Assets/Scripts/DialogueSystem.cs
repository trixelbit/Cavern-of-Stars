using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSystem : MonoBehaviour
{
    public TextAsset ConversationFile;

    [Header("Character Portraits")]
    public UnityEngine.Sprite Nin;
    public UnityEngine.Sprite Deya;

    private Conversation Convo;
    private int ConvoIndex;
    private string DialogueText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginDialogue(TextAsset JsonFile)
    {
        // Load Conversation from JSON File
        Convo = JsonUtility.FromJson<Conversation>(JsonFile.text);
        ConvoIndex = 0;
        GlobalData.Locked = true;
        DialogueText = Convo.conversation[ConvoIndex].Text;
    }

    public void NextDialogue()
    {
        if (ConvoIndex + 1 > Convo.conversation.Length)
        {
            // end conversation
            GlobalData.Locked = false;
        }
        else
        {
            // load next dialogue
            ConvoIndex++;
            DialogueText = Convo.conversation[ConvoIndex].Text;
        }
    }
}

[System.Serializable]
public class Conversation
{
    public Dialogue[] conversation;
}

[System.Serializable]
public class Dialogue
{
    public string SpeakerName;
    public string Text;
}



