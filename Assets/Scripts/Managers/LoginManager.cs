using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField Playername_InputField;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void connectToPhotonServer()
    {
        if(Playername_InputField != null)
        {
            PhotonNetwork.NickName = Playername_InputField.text;
            PhotonNetwork.ConnectUsingSettings();
        }
        else
        {
            PhotonNetwork.NickName = "devtest";
            PhotonNetwork.ConnectUsingSettings();
        }
     
    }

    public override void OnConnected()
    {
        Debug.Log("server is available");
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master server");
        gameObject.GetComponent<RoomManager>().JoinRandomRoom(); 
    }
}
