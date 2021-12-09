using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public void JoinRandomRoom()
    {
        Debug.Log("attempt to join room");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(message);
      if(returnCode == 32760) { 
        CreateAndJoinRoom();
    }
}
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName+"entered the game");
    }
    private void CreateAndJoinRoom()
    {
        Debug.Log("create room");
        RoomOptions roomOptions = new RoomOptions();

        roomOptions.MaxPlayers = 10;
        
        PhotonNetwork.CreateRoom("LWBP_DEVTEST2", roomOptions);
        
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Development_engine_room");
    }
}
