using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SessionData
{
    //Player
    public static GameObject Player;
    public static int Health = 10;
    public static int HealthCap = 10;
    public static int ComboCount = 0;
    public static float ComboTimeStamp = 0;

    public static void ResetComboCount()
    {
        ComboCount = 0;
    }

    public static void AddToComboCount()
    {
        if (SessionData.ComboCount == 0 || 0.1f > Time.time - SessionData.ComboTimeStamp)
        {
            SessionData.ComboCount++;
            SessionData.ComboTimeStamp = Time.time;
        }
    }

}
