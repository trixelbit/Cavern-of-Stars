using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SessionData
{

    //Player
    public static GameObject Player;
    public static int Health = 3;
    public static int HealthCap = 3;
    public static float RunSpeed = 14;

    public static bool DashUnlocked = true;
    public static float DashSpeed = 40;

    public static int ComboCount = 0;
    public static float ComboTimeStamp = 0;

    // Items
    public static int KeyCount = 0;

    //World State
    public static GameObject Camera;
    public static bool Lock = false;

    //Scene Traversal
    public static Vector3 CheckPointPosition;
    public static string CheckPointScene;

    public static Level[,] Forest;


    //

}


public class Level
{

    public string SceneName;
    public bool Active;
    public bool Checkpoint;
    public bool Completed;

    public Level(string sceneName)
    {
        SceneName = sceneName;
    }
}

