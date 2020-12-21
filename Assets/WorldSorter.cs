using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSorter : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < SceneManager.sceneCountInBuildSettings; i++)
        {
            Debug.Log("Scene" + i + " :" + NameFromIndex(i));
            string TempName = NameFromIndex(i);

            char World = TempName[0];
            int XCoord = int.Parse(TempName.Substring(1,2));
            int YCoord = int.Parse(TempName.Substring(4, 2));
            switch (World)
            {
                case 'A':
                    SessionData.Forest[XCoord, YCoord].SceneName = TempName;
                    break;

            }

            Debug.Log(SessionData.Forest);

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
}
