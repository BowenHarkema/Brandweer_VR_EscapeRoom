using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLagManager : MonoBehaviour
{   
    public List<GameObject> rooms;
    // Update is called once per frame
    public int currentRoom;

    void Update()
    {
        if(currentRoom == 2 || currentRoom == 3)
        {
            rooms[2].SetActive(true);
            rooms[3].SetActive(true);
        }
        else
            rooms[currentRoom].SetActive(true);
    }
    public void setCurrentRoom(int roomNumber)
    {
        currentRoom = roomNumber;
    }
}
