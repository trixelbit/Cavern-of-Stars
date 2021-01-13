using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimapSystem : MonoBehaviour
{
    /// <summary>
    /// Title: Minimap System Iteration: 1.0
    /// Type: UI Minimap System
    /// Description: A Minimap system that interacts with the Grid System established in the WorldData script to communicate to the player their current
    /// position and progress in the game.
    /// Method: Draws a 2D array of boxes intertwined with the WorldData script and labels each box according to whether it's an actual room or not, its name,
    /// whether it's been completed or not, and whether the player is currently present in it. A small version will always be present in the upper left-hand
    /// corner of the screen but the player can bring up the full version of the map with tab.
    /// Comments:
    /// </summary>

    #region Variables
    public GameObject single;
    public Level level;
    public bool playerPresent;

    #region Grid System Ver 2 Variables
    //Grid Draw Variables
    public float x_Start, y_Start;
    public float columnLength, rowLength;
    public float x_Space, y_Space;
    public GameObject gridParent;
    //public GameObject darkBG;
    //public GameObject bgParent;

    //Fading Variables
    private bool mFaded = true;
    public float Duration = 0.4f;

    //Sound Effects Variables
    public List<AudioClip> SoundEffects;
    static AudioSource audioSrc;

    //Map manipulation variables
    private float mouseY;
    private float mouseX;
    private float xRotation;
    public float LookSpeed = 3f;
    #endregion

    #region Grid System Ver 1 Variables
    public float[,] Grid;
    int Vertical, Horizontal, col, row;
    #endregion
    #endregion

    #region Start & Update
    // Start is called before the first frame update
    void Start()
    {
        audioSrc = this.GetComponent<AudioSource>();
        DrawGrid();
    }

    // Update is called once per frame
    void Update()
    {
        ShowFullMap();
        ManipulateGrid();
        ChangeGridScale();
    }
    #endregion

    #region Manipulate the Grid while Active

    void ManipulateGrid()
    {
        Vector3 moveDir;
        if (Input.GetMouseButton(2))
        {
            mouseY = Input.GetAxis("Mouse Y");
            mouseX = Input.GetAxis("Mouse X");
        }

        if (Input.GetMouseButtonUp(2))
        {
            mouseY = 0;
            mouseX = 0;
        }

        moveDir = transform.right * mouseX + transform.up * mouseY;
        gridParent.transform.Translate(moveDir * LookSpeed * Time.deltaTime);
    }

    float ChangeGridScale()
    {
        float ScaleFactor = 0.1f;
        float LookScaleMultiplier = 1;
        float temp = LookScaleMultiplier;
        var CurrentScale = gridParent.transform.localScale;

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            CurrentScale = new Vector3(CurrentScale.x + ScaleFactor, CurrentScale.y + ScaleFactor, CurrentScale.z + ScaleFactor);
            temp += ScaleFactor;
            LookScaleMultiplier = temp;
            gridParent.transform.localScale = CurrentScale;
            

        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            CurrentScale = new Vector3(CurrentScale.x - ScaleFactor, CurrentScale.y - ScaleFactor, CurrentScale.z - ScaleFactor);
            gridParent.transform.localScale = CurrentScale;
        }

        return LookScaleMultiplier;
    }

    void ResetGrid()
    {
        gridParent.transform.localScale = new Vector3(1,1,1);
        gridParent.transform.localPosition = new Vector3(0,0,0);
    }

    #endregion

    #region Bring up the Full Minimap and Fade

    //Bring up Full Minimap
    void ShowFullMap()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Fade();
        }
    }

    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        // Toggle the end value depending on the faded state
        StartCoroutine(DoFade(canvGroup, canvGroup.alpha, mFaded ? 1 : 0));

        // Toggle the faded state
        mFaded = !mFaded;
    }

    public IEnumerator DoFade(CanvasGroup canvGroup, float start, float end)
    {
        float counter = 0f;

        //Menu Sound Effect
        PlaySoundEffect((int)end);

        while (counter < Duration)
        {
            counter += Time.deltaTime;
            canvGroup.alpha = Mathf.Lerp(start, end, counter / Duration);

            if (canvGroup.alpha == 0)
            {
                ResetGrid();
            }

            yield return null;
        }
    }

    public void PlaySoundEffect(int index)
    {
        int i = index;
        audioSrc.PlayOneShot(SoundEffects[i]);
    }
    
    #endregion

    #region Draw Grid and Update the State of it
    //Draw the Grid for the Minimap
    void DrawGrid()
    {
        for (int i = 0; i <= columnLength; i++)
        {
            for (int j = 0; j <= rowLength; j++)
            {
                var singleClone = Instantiate(single, new Vector3(x_Start + x_Space * i, y_Start + (-y_Space * j)), Quaternion.identity);

                if (GlobalData.Forest[i, j].SceneName[0] == '_')
                {
                    Destroy(singleClone);
                }

                if (GlobalData.Forest[i,j].SceneName[0] != '_')
                {   
                    singleClone.name = ("x: " + i + " y: " + j);
                    singleClone.GetComponent<Image>().color = new Color(100, 100, 100);
                    singleClone.name = ("OCCx: " + i + " OCCy: " + j);
                }

                if (GlobalData.CurrentRoomCoord == new Vector2(i, j))
                {
                    singleClone.GetComponent<Image>().color = new Color(0, 255, 255);
                    singleClone.name = ("CURRENTx: " + i + " CURRENTy: " + j);
                }
                singleClone.transform.parent = gridParent.transform;

            singleClone.layer = 5;
            }
        }
    }
    #endregion

    #region Grid System Ver 1
    /*private void SpawnTile(int x, int y, float value)
    {
        Vertical = (int)Camera.main.orthographicSize;
        Horizontal = (int)(Vertical * (float)(Screen.width / Screen.height));
        col = Horizontal * 2;
        row = Vertical * 2;
        Grid = new float[col, row];
        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Grid[i, j] = Random.Range(0.0f, 10.0f);
                SpawnTile(i, j, Grid[i, j]);
            }
        }
        GameObject g = new GameObject("x: " +x + "y: " + y);
        g.transform.position = new Vector3(x - (Horizontal - 0.5f), y - (Vertical - 0.5f));
        var s = g.AddComponent<SpriteRenderer>();
        s.color = new Color(value, value, value);
    }*/
    #endregion
}
