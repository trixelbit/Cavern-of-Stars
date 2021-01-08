using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapSystem : MonoBehaviour
{
    public GameObject single;
    public Level level;
    public bool playerPresent;
    public Level[,] ReferenceArray;

    // Start is called before the first frame update
    void Start()
    {
        ReferenceArray = GlobalData.Forest;
        printWorldBlock();
        DrawGrid();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Draw the Grid for the Minimap
    void DrawGrid()
    {
        for (int col = 0; col < 24; col++)
        {
            for (int row = 0; row < 24; row++)
            {
                if (GlobalData.Forest[col, row].SceneName[0] != '_')
                {
                    Debug.Log("Instantiating UI Element...");
                    Instantiate(single, new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
                    Debug.Log("Instantiated UI Element!");
                }

                else
                {
                    Debug.Log("Instantiating Empty");
                }


            }
        }
    }
    //Actual Level Minimap
        void UpdateState()
        {

        }

    //Minimap Visualization
        private void printWorldBlock()
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
        }
    }
