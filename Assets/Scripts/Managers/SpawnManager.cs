using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    public GameObject PlayerObject;
    public Camera PlayerCam;

    public List<GameObject> Spawnpos;
    public List<Canvas> canvas;

    private GameObject _Player;

    // Start is called before the first frame update
    void Start()
    {
        //checks if player is connected to photon and ready then spawns
        if (PhotonNetwork.IsConnectedAndReady)
        {
            foreach (Canvas canvas in canvas)
            {
                canvas.worldCamera = PlayerCam;
            }
        _Player = PhotonNetwork.Instantiate(PlayerObject.name, Spawnpos[CheckPlayerCount()].transform.position,Quaternion.identity);
            //CheckPlayerCount()
        }
    }

    //checks amount of players connected to current photon server
    private int CheckPlayerCount()
    {
        return PhotonNetwork.CountOfPlayers;
    }
}
