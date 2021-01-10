using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    private RectTransform Chatbox;
    private Vector3 ChatBoxStartPosition;

    // Start is called before the first frame update
    void Awake()
    {
        GlobalData.Canvas = gameObject;
        Chatbox = transform.GetChild(2).GetComponent<RectTransform>();
        ChatBoxStartPosition = Chatbox.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.ChatBoxIsActive)
        {
            Chatbox.anchoredPosition = Vector3.Lerp( Chatbox.anchoredPosition, Vector3.down * 600 , .1f);
            //Chatbox.transform.position = Vector3.Lerp(Chatbox.transform.position, ChatBoxStartPosition + new Vector3(0, -600, 0), .1f);
        }
        else 
        {
            Chatbox.anchoredPosition = Vector3.Lerp(Chatbox.anchoredPosition, new Vector3(0,0,0), .1f);
            //Chatbox.transform.position = Vector3.Lerp(Chatbox.transform.position, ChatBoxStartPosition, .1f);
        }
    }
}
