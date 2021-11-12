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

    [SerializeField] private ExitGames.Client.Photon.Hashtable GenProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable LifeProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable EngineProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable CoreProp = new ExitGames.Client.Photon.Hashtable();


    public UnityEvent GeneratorsEvent = new UnityEvent();
    public UnityEvent PlantPodsEvent = new UnityEvent();
    public UnityEvent EngineEvent = new UnityEvent();
    public UnityEvent CoreEvent = new UnityEvent();

    //set the custom properties
    private void Start()
    {
        GenProp["Generators"] = false;
        LifeProp["LifeSupport"] = false;
        EngineProp["Engines"] = false;
        CoreProp["Core"] = false;

        PhotonNetwork.CurrentRoom.SetCustomProperties(GenProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(LifeProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(EngineProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(CoreProp);
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
    }

    //Function for activating event when room is fixed
    public void RoomFixed(int fixedroom)
    {
        switch(fixedroom)
        {
            //generator
            case 1:
                GenProp["Generators"] = true;
                _AllGeneratorsUp = true;
                PhotonNetwork.CurrentRoom.SetCustomProperties(GenProp);
                GeneratorsEvent.Invoke();
                break;

            //plant pods
            case 2:
                LifeProp["LifeSupport"] = true;
                _AllPodsBalanced = true;
                PhotonNetwork.CurrentRoom.SetCustomProperties(LifeProp);
                PlantPodsEvent.Invoke();
                break;

            //engine
            case 3:
                EngineProp["Engines"] = true;
                _EnginesUp = true;
                PhotonNetwork.CurrentRoom.SetCustomProperties(EngineProp);
                EngineEvent.Invoke();
                break;

            //core
            case 4:
                CoreProp["Core"] = true;
                _CoreUp = true;
                PhotonNetwork.CurrentRoom.SetCustomProperties(CoreProp);
                CoreEvent.Invoke();
                break;

            default:
                break;
        }
    }
}
