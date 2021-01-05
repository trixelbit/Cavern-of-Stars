using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomExit : MonoBehaviour
{
    public World CurrentWorld;
    public OrientationInRoom ExitDirection;

    // Start is called before the first frame update
    private void Start()
    {
        GlobalData.ExitObjects[(int)ExitDirection] = gameObject;
        if (GlobalData.EntrancePoint == ExitDirection)
        {
            GlobalData.Player.transform.position = transform.GetChild(0).transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GlobalData.EntrancePoint = ExitDirection;
            GlobalData.BlackScreen.GetComponent<SceneFade>().Visible = true;
            Invoke("GoToNextRoom", .3f);
        }
    }


    public void GoToNextRoom()
    {
        switch(ExitDirection)
        {
            case OrientationInRoom.South:
                GlobalData.CurrentRoomCoord += new Vector2(0, 1);
                GlobalData.EntrancePoint = OrientationInRoom.North;
                break;
            case OrientationInRoom.West:
                GlobalData.CurrentRoomCoord += new Vector2(-1, 0);
                GlobalData.EntrancePoint = OrientationInRoom.East;
                break;

            case OrientationInRoom.East:
                GlobalData.CurrentRoomCoord += new Vector2(1, 0);
                GlobalData.EntrancePoint = OrientationInRoom.West;
                break;

            case OrientationInRoom.North:
                GlobalData.CurrentRoomCoord += new Vector2(0, -1);
                GlobalData.EntrancePoint = OrientationInRoom.South;
                break;

        }

        

        switch (GlobalData.CurrentWorld)
        {
            case World.Forest:
                //If room exists -> Load Scene By Name
                if (GlobalData.Forest[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName != "_")
                {
                    GlobalData.EnemyCount = 0;
                    SceneManager.LoadScene(GlobalData.Forest[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName);
                    
                }
                else // If room doesn't exist -> fade back in
                {
                    GlobalData.BlackScreen.GetComponent<SceneFade>().Visible = false;
                }
                break;

            case World.Cavern:
                if (GlobalData.Forest[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName != "_")
                {
                    SceneManager.LoadScene(GlobalData.Cavern[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName);
                }
                break;
            
            case World.City:
                if (GlobalData.Forest[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName != "_")
                {
                    SceneManager.LoadScene(GlobalData.City[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName);
                }
                break;

            case World.Castle:
                if (GlobalData.Forest[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName != "_")
                {
                    SceneManager.LoadScene(GlobalData.City[(int)GlobalData.CurrentRoomCoord.x, (int)GlobalData.CurrentRoomCoord.y].SceneName);
                }
                break;
        }

        

    }
}

