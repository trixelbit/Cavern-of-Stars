using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class DialogueSystem : MonoBehaviour
{
    public TextAsset ConversationFile;

    [Header("Character Portraits")]
    public UnityEngine.Sprite Nin;
    public UnityEngine.Sprite Deya;

    private Dialogue Convo;
    private int ConvoIndex;
    private string DialogueText;

    // Start is called before the first frame update
    void Start()
    {
        BeginDialogue(ConversationFile);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextDialogue();
        }

    }

    public void BeginDialogue(TextAsset JsonFile)
    {
        // Load Conversation from JSON File
        ConvoIndex = 0;
        Convo = JsonUtility.FromJson<Dialogue>(JsonFile.text);
        GlobalData.Locked = true;
        DialogueText = Convo.Conversation[ConvoIndex].Text;
        Debug.Log(DialogueText);
        GlobalData.Canvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = DialogueText;
    }

    public void NextDialogue()
    {
        if (ConvoIndex + 1 > Convo.Conversation.Length)
        {
            // end conversation
            GlobalData.Locked = false;
        }
        else
        {
            // load next dialogue
            ConvoIndex++;
            DialogueText = Convo.Conversation[ConvoIndex].Text;
            GlobalData.Canvas.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = DialogueText;
        }
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
}



