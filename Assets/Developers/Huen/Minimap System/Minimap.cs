using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    //Grid Draw Variables
    public GameObject mmSingle;
    public GameObject mmGridParent;
    public float x_Start, y_Start;
    public float columnLength, rowLength;
    public float x_Space, y_Space;

    //Fading Variables
    private bool mFaded = false;
    public float Duration = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        DrawMap();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Fade();
        }
    }

    //Action
    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        // Toggle the end value depending on the faded state
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        // Toggle the faded state
        mFaded = !mFaded;
    }

    //Visual
    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            yield return null;
        }
    }

    void DrawMap()
    {
        for (int i = 0; i <= columnLength; i++)
        {
            for (int j = 0; j <= rowLength; j++)
            {
                var singleClone = gameObject;

                if (GlobalData.Forest[i, j].SceneName[0] != '_')
                {
                    singleClone = Instantiate(mmSingle, new Vector3(x_Start + x_Space % mmGridParent.transform.position.x, y_Start + (-y_Space * j)), Quaternion.identity);
                    singleClone.name = ("x: " + i + " y: " + j);
                    singleClone.GetComponent<Image>().color = new Color(100, 100, 100);
                    singleClone.name = ("OCCx: " + i + " OCCy: " + j);
                }

                if (GlobalData.CurrentRoomCoord == new Vector2(i, j))
                {
                    singleClone.GetComponent<Image>().color = new Color(0, 255, 255);
                    singleClone.name = ("CURRENTx: " + i + " CURRENTy: " + j);
                }

                singleClone.transform.parent = mmGridParent.transform;

                singleClone.layer = 5;
            }
        }
    }
}
