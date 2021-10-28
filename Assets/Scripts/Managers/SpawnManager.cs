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

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            foreach (Canvas canvas in canvas)
            {
                canvas.worldCamera = PlayerCam;
            }
        player = PhotonNetwork.Instantiate(PlayerObject.name, Spawnpos[CheckPlayerCount()].transform.position,Quaternion.identity);
        }
    }

    private int CheckPlayerCount()
    {
        return PhotonNetwork.CountOfPlayers;
    }
}
