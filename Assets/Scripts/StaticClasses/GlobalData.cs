using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OrientationInRoom
{ 
    North=0,
    South=1,
    West=2,
    East=3
};

public enum World
{ 
    Forest=0,
    Cavern=1,
    City=2,
    Castle=3
};

public static class GlobalData
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
    public static int EnemyCount = 0;
    #endregion

    #region Room Traversal

    public static Vector2 CurrentRoomCoord = new Vector2(12,23);
    public static Vector3 CheckPointPosition;
    public static string CheckPointScene;
    public static OrientationInRoom EntrancePoint = OrientationInRoom.South;

    /* 24 x 24 Worlds (24 scenes x 24 scenes)
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
    public static GameObject[] ExitObjects = { null, null, null, null };
    #endregion

    #region UI References
    public static GameObject Canvas;
    public static GameObject BlackScreen;
    
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

