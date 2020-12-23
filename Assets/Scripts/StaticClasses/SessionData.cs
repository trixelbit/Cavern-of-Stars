using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrientationInRoom
{ 
    North,
    South,
    West,
    East
};

public enum World
{ 
    Forest=0,
    Cavern=1,
    City=2,
    Castle=3
};


public static class SessionData
{
    #region Player Information
    public static GameObject Player;
    public static int Health = 3;
    public static int HealthCap = 3;
    public static float RunSpeed = 14;

    public static bool DashUnlocked = true;
    public static float DashSpeed = 40;

    public static int ComboCount = 0;
    public static float ComboTimeStamp = 0;
    #endregion

    #region Items
    public static int KeyCount = 0;
    #endregion

    #region World State
    public static GameObject Camera;
    public static bool Lock = false;
    #endregion

    #region Room Traversal

    public static Vector2 CurrentRoomCoord;
    public static Vector3 CheckPointPosition;
    public static string CheckPointScene;
    public static OrientationInRoom EntrancePoint;


    /*
     * 
     * 
     * 24 x 24 Rooms
     *
     * [0,0]
     *      _____________
     *      |           |
     *      |           |
     *      |           |
     *      |           |
     *      |___________|
     * [0,24]  [12,24]  [23,23]
     *            ^
     *      Starting Room
     *    
     */

    public static World CurrentWorld;
    public static Level[,] Forest;
    public static Level[,] Cavern;
    public static Level[,] City;
    public static Level[,] Castle;
    #endregion
}

public class Level
{
    public string SceneName;
    public bool Checkpoint;
    public bool Completed;

    public Level(string sceneName)
    {
        SceneName = sceneName;
    }
}

