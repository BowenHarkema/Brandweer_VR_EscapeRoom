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

    public GameObject EscapeRoomManager;

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
      EscapeRoomManager.GetComponent<EscapeRoomManager>().TimeDisplays.Add(player.gameObject.transform.Find("Avatar5").Find("HandL").Find("Watch").Find("Canvas").Find("time display").GetComponent<TextMeshProUGUI>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private int CheckPlayerCount()
    {
        return PhotonNetwork.CountOfPlayers;
    }
}
