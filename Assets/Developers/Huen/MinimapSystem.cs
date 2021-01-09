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
    public Level[,] ReferenceArray;

    #region Grid System Ver 2 Variables
    public float x_Start, y_Start;
    public int columnLength, rowLength;
    public float x_Space, y_Space;
    public GameObject gridParent;
    public GameObject darkBG;
    public GameObject bgParent;

    #endregion

    #region Grid System Ver 1 Variables
    public UnityEngine.Sprite sprite;
    public float[,] Grid;
    int Vertical, Horizontal, col, row;
    #endregion
    #endregion

    #region Start & Update
    // Start is called before the first frame update
    void Start()
    {
        var MapBG = Instantiate(darkBG, transform.position, Quaternion.identity);
        MapBG.transform.parent = bgParent.transform;
        MapBG.transform.localScale = bgParent.transform.localScale;

        for (int i = 0; i < columnLength * rowLength; i++)
        {
            var singleClone = Instantiate(single, new Vector3(x_Start + x_Space * (i % columnLength), y_Start + y_Space * (i / columnLength)), Quaternion.identity);
            singleClone.name = ("x: " + i + " y: " + i);
            singleClone.transform.parent = gridParent.transform;
            singleClone.layer = 5;
        }
        ReferenceArray = GlobalData.Forest;
        DrawGrid();
        UpdateState();
    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Draw Grid and Update the State of it
    //Draw the Grid for the Minimap
    void DrawGrid()
    {
        for (int col = 0; col < 24; col++)
        {
            for (int row = 0; row < 24; row++)
            {
                /*if (GlobalData.Forest[col, row].SceneName[0] != '_')
                {
                    Debug.Log("Instantiating UI Element...");
                    Instantiate(single, new Vector3(0,0,0), Quaternion.Euler(0, 0, 0));
                    Debug.Log("Instantiated UI Element!");
                }

                else
                {
                    Debug.Log("Instantiating Empty");
                }*/


            }
        }
    }

    //Actual Level Minimap
        void UpdateState()
        {

        }
    #endregion

    #region Bring up the Full Minimap
    //Bring up Full Minimap
    void ShowFullMap()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        { 
        
        }
    }
    #endregion

    #region Console Visualization
    //Minimap Visualization
    /*private void printWorldBlock()
        {
            string buffer = "";
            for (int i = 0; i < 24; i++)
            {
                buffer += "[";
                for (int j = 0; j < 24; j++)
                {
                    if (GlobalData.Forest[j, i].SceneName[0] != '_')
                    {
                        buffer += "#";
                    }
                    else
                    {
                        buffer += GlobalData.Forest[j, i].SceneName[0];
                    }


                }
                buffer += "]\n";

            }

            Debug.Log(buffer);
        }*/
    #endregion

    #region Grid System Ver 1
    private void SpawnTile(int x, int y, float value)
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
        s.sprite = sprite;
        s.color = new Color(value, value, value);
    }
    #endregion
}
