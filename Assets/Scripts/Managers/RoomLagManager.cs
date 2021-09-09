using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomLagManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    public List<GameObject> rooms;
    // Update is called once per frame
    public int currentRoom;
    public void Start()
    {
        
    }
    void Update()
    {
        
        rooms[currentRoom].SetActive(true);

    }
    public void setCurrentRoom(int roomNumber)
    {
        currentRoom = roomNumber;
    }
}
