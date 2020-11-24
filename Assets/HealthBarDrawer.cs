using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDrawer : MonoBehaviour
{
    public GameObject HeartSprite;
    public GameObject BackSprite;
    public float HorizontalSpacing = 10;
    public Vector2 Offset = new Vector2(0, 1080);

    private GameObject[] HeartSprites = new GameObject[SessionData.HealthCap];

    // Start is called before the first frame update
    void Start()
    {
        GameObject ObjectReference;
        Offset.x += HeartSprite.GetComponent<RectTransform>().rect.width / 2;
        Offset.y -= HeartSprite.GetComponent<RectTransform>().rect.height / 2;

        // heart containers
        for (int i = 0; i < SessionData.HealthCap; i++)
        {
            ObjectReference = Instantiate(BackSprite);
            ObjectReference.transform.SetParent(gameObject.transform);
            ObjectReference.transform.position = new Vector3(Offset.x, Offset.y, 0);
            ObjectReference.transform.position += new Vector3(i * HorizontalSpacing, 0, 0);
            HeartSprites[i] = ObjectReference;
        }

        // hearts
        for (int i = 0; i < SessionData.HealthCap; i++)
        {
            ObjectReference = Instantiate(HeartSprite);
            ObjectReference.transform.SetParent(gameObject.transform);
            ObjectReference.transform.position = new Vector3(Offset.x, Offset.y, 0);
            ObjectReference.transform.position += new Vector3( i * HorizontalSpacing, 0, 0 );
            HeartSprites[i] = ObjectReference;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // update heart containers
        for(int i = 0; i < SessionData.HealthCap; i++)
        {
            if ( i < SessionData.Health )
            {
                HeartSprites[i].SetActive(true);
            }
            else
            {
                HeartSprites[i].SetActive(false);
            }
        }
    }
}
