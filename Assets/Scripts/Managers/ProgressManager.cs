using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private bool _AllGeneratorsUp;
    [SerializeField] private bool _AllPodsBalanced;
    [SerializeField] private bool _EnginesUp;
    [SerializeField] private bool _CoreUp;
    [SerializeField] private bool _Gamestarted;

    [SerializeField] private ExitGames.Client.Photon.Hashtable GenProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable LifeProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable EngineProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable CoreProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable GameStartProp = new ExitGames.Client.Photon.Hashtable();


    public UnityEvent GeneratorsEvent = new UnityEvent();
    public UnityEvent PlantPodsEvent = new UnityEvent();
    public UnityEvent EngineEvent = new UnityEvent();
    public UnityEvent CoreEvent = new UnityEvent();
    public UnityEvent GameStartEvent = new UnityEvent();

    //set the custom properties
    private void Start()
    {
        GenProp["Generators"] = false;
        LifeProp["LifeSupport"] = false;
        EngineProp["Engines"] = false;
        CoreProp["Core"] = false;
        GameStartProp["GameStart"] = false;

        PhotonNetwork.CurrentRoom.SetCustomProperties(GenProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(LifeProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(EngineProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(CoreProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(GameStartProp);
    }

    //Check if one of the properties is updated
    void Update()
    {
        if(_AllGeneratorsUp != (bool)PhotonNetwork.CurrentRoom.CustomProperties["Generators"])
        {
            RoomFixed(1);
        }
        else if (_AllPodsBalanced != (bool)PhotonNetwork.CurrentRoom.CustomProperties["LifeSupport"])
        {
            RoomFixed(2);
        }
        else if (_EnginesUp != (bool)PhotonNetwork.CurrentRoom.CustomProperties["Engines"])
        {
            RoomFixed(3);
        }
        else if (_CoreUp != (bool)PhotonNetwork.CurrentRoom.CustomProperties["Core"])
        {
            RoomFixed(4);
        }
        else if (_Gamestarted != (bool)PhotonNetwork.CurrentRoom.CustomProperties["GameStart"])
        {
            RoomFixed(5);
        }
    }

    //Function for activating event when room is fixed
    public void RoomFixed(int fixedroom)
    {
        switch(fixedroom)
        {
            case 1:
                if(!_AllGeneratorsUp)
                {
                    GenProp["Generators"] = true;
                    _AllGeneratorsUp = true;
                    PhotonNetwork.CurrentRoom.SetCustomProperties(GenProp);
                    GeneratorsEvent.Invoke();
                }
                break;

            case 2:
                if (!_AllPodsBalanced)
                {
                    LifeProp["LifeSupport"] = true;
                    _AllPodsBalanced = true;
                    PhotonNetwork.CurrentRoom.SetCustomProperties(LifeProp);
                    PlantPodsEvent.Invoke();
                }
                break;

            case 3:
                if (!_EnginesUp)
                {
                    EngineProp["Engines"] = true;
                    _EnginesUp = true;
                    PhotonNetwork.CurrentRoom.SetCustomProperties(EngineProp);
                    EngineEvent.Invoke();
                }
                break;

            case 4:
                if (!_CoreUp)
                {
                    CoreProp["Core"] = true;
                    _CoreUp = true;
                    PhotonNetwork.CurrentRoom.SetCustomProperties(CoreProp);
                    CoreEvent.Invoke();
                }
                break;

            case 5:
                CoreProp["GameStart"] = true;
                _Gamestarted = true;
                PhotonNetwork.CurrentRoom.SetCustomProperties(GameStartProp);
                GameStartEvent.Invoke();
                break;

            default:
                break;
        }
    }
}
