﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSorter : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        // initialize worlds
        SessionData.Forest = new Level[24, 24];
        for (int i = 0; i < 24; i++)
        {
            for (int j = 0; j < 24; j++)
            {
                SessionData.Forest[i, j] = new Level("_");
            }

        }
        
        // Sort All Scenes into proper World Maps
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            Debug.Log("Scene" + i + " :" + NameFromIndex(i));
            string TempName = NameFromIndex(i);

            char World = TempName[0];
            int XCoord = int.Parse(TempName.Substring(1, 2));
            int YCoord = int.Parse(TempName.Substring(4, 2));
            Debug.Log(XCoord + ", " + YCoord);
            switch (World)
            {
                case 'A':
                    SessionData.Forest[XCoord, YCoord].SceneName = TempName;
                    break;

                case 'B':
                    SessionData.Cavern[XCoord, YCoord].SceneName = TempName;
                    break;

                case 'C':
                    SessionData.City[XCoord, YCoord].SceneName = TempName;
                    break;

                case 'D':
                    SessionData.Castle[XCoord, YCoord].SceneName = TempName;
                    break;
            }
        }
    }

    private static string NameFromIndex(int BuildIndex)
    {
        string path = SceneUtility.GetScenePathByBuildIndex(BuildIndex);
        int slash = path.LastIndexOf('/');
        string name = path.Substring(slash + 1);
        int dot = name.LastIndexOf('.');
        return name.Substring(0, dot);
    }

    private void printWorldBlock()
    {
        string buffer = "";
        for (int i = 0; i < 24; i++)
        {
            buffer += "[";
            for (int j = 0; j < 24; j++)
            {
                if (SessionData.Forest[j, i].SceneName[0] != '_')
                {
                    buffer += "#";
                }
                else
                {
                    buffer += SessionData.Forest[j, i].SceneName[0];
                }


            }
            buffer += "]\n";

        }

        Debug.Log(buffer);
    }


}
