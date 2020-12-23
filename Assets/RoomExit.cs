using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomExit : MonoBehaviour
{
    public World CurrentWorld;
    public OrientationInRoom ExitDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        SessionData.ExitObjects[(int)ExitDirection] = gameObject;
        if (SessionData.EntrancePoint == ExitDirection)
        {
            SessionData.Player.transform.position = transform.GetChild(0).transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SessionData.EntrancePoint = ExitDirection;
            Invoke("GoToNextRoom", .2f);
        }
    }


    public void GoToNextRoom()
    {
        switch(ExitDirection)
        {
            case OrientationInRoom.South:
                SessionData.CurrentRoomCoord += new Vector2(0, 1);
                SessionData.EntrancePoint = OrientationInRoom.North;
                break;
            case OrientationInRoom.West:
                SessionData.CurrentRoomCoord += new Vector2(-1, 0);
                SessionData.EntrancePoint = OrientationInRoom.East;
                break;

            case OrientationInRoom.East:
                SessionData.CurrentRoomCoord += new Vector2(1, 0);
                SessionData.EntrancePoint = OrientationInRoom.West;
                break;

            case OrientationInRoom.North:
                SessionData.CurrentRoomCoord += new Vector2(0, -1);
                SessionData.EntrancePoint = OrientationInRoom.South;
                break;

        }

        switch (SessionData.CurrentWorld)
        {
            case World.Forest:
                SceneManager.LoadScene(SessionData.Forest[(int)SessionData.CurrentRoomCoord.x, (int)SessionData.CurrentRoomCoord.y].SceneName);
                break;

            case World.Cavern:
                SceneManager.LoadScene(SessionData.Cavern[(int)SessionData.CurrentRoomCoord.x, (int)SessionData.CurrentRoomCoord.y].SceneName);
                break;
            
            case World.City:
                SceneManager.LoadScene(SessionData.City[(int)SessionData.CurrentRoomCoord.x, (int)SessionData.CurrentRoomCoord.y].SceneName);
                break;

            case World.Castle:
                SceneManager.LoadScene(SessionData.Castle[(int)SessionData.CurrentRoomCoord.x, (int)SessionData.CurrentRoomCoord.y].SceneName);
                break;


        }

    }
}

