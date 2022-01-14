using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Events;
using Photon.Pun;

public class StartSystemManager : MonoBehaviourPunCallbacks
{
    public static StartSystemManager _Current;

    [SerializeField]
    private string _Sequence_Order;

    [SerializeField]
    private string _Current_Sequence_Order;
    public string P_Current_sequence_Order { get { return _Current_Sequence_Order; } }

    [SerializeField] private bool _EnergyFixed = false;
    public bool P_EnergyFixed { get { return _EnergyFixed; } set { _EnergyFixed = value; } }

    [SerializeField] private bool _CoolingFixed = false;
    public bool P_CoolingFixed { get { return _CoolingFixed; } set { _CoolingFixed = value; } }

    [SerializeField] private ProgressManager _ProgressManager;

    //Sync vars 
    [SerializeField] private ExitGames.Client.Photon.Hashtable _SequenceListProp = new ExitGames.Client.Photon.Hashtable();

    //Set the manager as singleton item.
    private void Awake()
    {
        _Current = this;
        _SequenceListProp["SequenceEngine"] = "";
        PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceListProp);
    }

    //Fixed update to check data and fix items.
    private void FixedUpdate()
    {
        if (_Current_Sequence_Order.Length > _Sequence_Order.Length)
        {
            _Current_Sequence_Order = "";
        }

        if (_Current_Sequence_Order.Length == _Sequence_Order.Length)
        {
            if (_Current_Sequence_Order.SequenceEqual(_Sequence_Order) && _EnergyFixed && _CoolingFixed)
            {
                _ProgressManager.RoomFixed(3);
            }
            else
            {
                Debug.Log("Try again");
                _Current_Sequence_Order = "";
            }
        }
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable property)
    {
        Debug.Log(property);
        if (property.ContainsKey("SequenceEngine"))
        {
            _Current_Sequence_Order = (string)PhotonNetwork.CurrentRoom.CustomProperties["SequenceEngine"];
            Debug.Log("property changed: " + _Current_Sequence_Order);
        }
    }

    //event and function for manager.
    public event Action OnAbutton;
    public void Abutton()
    {
        if (OnAbutton != null)
        {
            OnAbutton();
            _Current_Sequence_Order += "1";
            _SequenceListProp["SequenceEngine"] = _Current_Sequence_Order;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceListProp);
        }
    }

    //event and function for manager.
    public event Action OnBbutton;
    public void Bbutton()
    {
        if (OnBbutton != null)
        {
            OnBbutton();
            _Current_Sequence_Order += "2";
            _SequenceListProp["SequenceEngine"] = _Current_Sequence_Order;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceListProp);
        }
    }

    //event and function for manager.
    public event Action OnCbutton;
    public void Cbutton()
    {
        if (OnBbutton != null)
        {
            OnDbutton();
            _Current_Sequence_Order += "3";
            _SequenceListProp["SequenceEngine"] = _Current_Sequence_Order;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceListProp);
        }
    }

    //event and function for manager.
    public event Action OnDbutton;
    public void Dbutton()
    {
        if (OnBbutton != null)
        {
            OnDbutton();
            _Current_Sequence_Order += "4";
            _SequenceListProp["SequenceEngine"] = _Current_Sequence_Order;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceListProp);
        }
    }
}