using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Photon.Pun;

public class Energy_Manager : MonoBehaviourPunCallbacks
{
    public static Energy_Manager _Current;

    [SerializeField]
    private float _EnergyGreen;
    public float P_EnergyGreen { get { return _EnergyGreen; } }

    [SerializeField]
    private float _EnergyRed;
    public float P_EnergyRed { get { return _EnergyRed; } }

    [Header("General settings")]
    [SerializeField]
    private int _MaxEnergy;
    public int P_MaxEnergy { get { return _MaxEnergy; } }

    [SerializeField]
    [Range(0, 50)]
    private int _RaiseLowerStep;

    [Header("Settings for when energy is fixed")]
    [Tooltip("Hiermee kun je de range bepalen waarop de energy fixed moet zijn. Dit moet samen komen tot maxenergy")]
    [SerializeField]
    private int _TargetEnergyRed;
    [SerializeField]
    private int _TargetEnergyGreen;
    [SerializeField]
    private int _DismissRange;

    [SerializeField] private ProgressManager _ProgressManager;

    //Sync vars 
    [SerializeField] private ExitGames.Client.Photon.Hashtable _RedEnergyProp = new ExitGames.Client.Photon.Hashtable();
    [SerializeField] private ExitGames.Client.Photon.Hashtable _GreenEnergyProp = new ExitGames.Client.Photon.Hashtable();

    //Set the manager as singleton item.
    private void Awake()
    {
        _Current = this;

        _EnergyGreen = _MaxEnergy / 2;
        _EnergyRed = _MaxEnergy / 2;

        _RedEnergyProp["RedEnergy"] = _EnergyRed;
        _GreenEnergyProp["GreenEnergy"] = _EnergyGreen;

        PhotonNetwork.CurrentRoom.SetCustomProperties(_RedEnergyProp);
        PhotonNetwork.CurrentRoom.SetCustomProperties(_GreenEnergyProp);
    }

    //Fixed update to check data and fix items.
    private void Update()
    {
        /*        _EnergyRed = (float)PhotonNetwork.CurrentRoom.CustomProperties["RedEnergy"];
                _EnergyGreen = (float)PhotonNetwork.CurrentRoom.CustomProperties["GreenEnergy"];*/

        if (_EnergyGreen >= _TargetEnergyGreen - _DismissRange && _EnergyGreen <= _TargetEnergyGreen + _DismissRange
            && _EnergyRed >= _TargetEnergyRed - _DismissRange && _EnergyRed <= _TargetEnergyRed + _DismissRange)
        {
            _ProgressManager.RoomFixed(3);
        }
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable property)
    {
        Debug.Log(property);
        if (property.ContainsKey("RedEnergy"))
        {
            _EnergyRed = (float)PhotonNetwork.CurrentRoom.CustomProperties["RedEnergy"];
            Debug.Log("property changed: " + _EnergyRed);
        }
        if (property.ContainsKey("GreenEnergy"))
        {
            _EnergyGreen = (float)PhotonNetwork.CurrentRoom.CustomProperties["GreenEnergy"];
            Debug.Log("property changed: " + _EnergyRed);
        }

    }

    //event and function for manager.
    public event Action OnLowerEnergyGreen;
    public void LowerEnergyGreen()
    {
        if (OnLowerEnergyGreen != null)
        {
            OnLowerEnergyGreen();

            if (_EnergyGreen >= 0 && _EnergyGreen <= _MaxEnergy)
            {
                _EnergyGreen -= _RaiseLowerStep * Time.deltaTime;
                _GreenEnergyProp["GreenEnergy"] = _EnergyGreen;
                PhotonNetwork.CurrentRoom.SetCustomProperties(_GreenEnergyProp);
            }

            if (_EnergyRed >= 0 && _EnergyRed <= _MaxEnergy)
            {
                _EnergyRed += _RaiseLowerStep * Time.deltaTime;
                _RedEnergyProp["RedEnergy"] = _EnergyRed;
                PhotonNetwork.CurrentRoom.SetCustomProperties(_RedEnergyProp);
            }

            if (_EnergyGreen <= 0)
            {
                _EnergyGreen = 0.1f;
            }

            if (_EnergyGreen >= _MaxEnergy)
            {
                _EnergyGreen = _MaxEnergy - 0.1f;
            }

            if (_EnergyRed <= 0)
            {
                _EnergyRed = 0.1f;
            }

            if (_EnergyRed >= _MaxEnergy)
            {
                _EnergyRed = _MaxEnergy - 0.1f;
            }
        }
    }

    //event and function for manager.
    public event Action OnLowerEnergyRed;
    public void LowerEnergyRed()
    {
        if (OnLowerEnergyRed != null)
        {
            OnLowerEnergyRed();
            if (_EnergyGreen >= 0 && _EnergyGreen <= _MaxEnergy)
            {
                _EnergyGreen += _RaiseLowerStep * Time.deltaTime;
                _GreenEnergyProp["GreenEnergy"] = _EnergyGreen;
                PhotonNetwork.CurrentRoom.SetCustomProperties(_GreenEnergyProp);
            }

            if (_EnergyRed >= 0 && _EnergyRed <= _MaxEnergy)
            {
                _EnergyRed -= _RaiseLowerStep * Time.deltaTime;
                _RedEnergyProp["RedEnergy"] = _EnergyRed;
                PhotonNetwork.CurrentRoom.SetCustomProperties(_RedEnergyProp);
            }

            if (_EnergyGreen <= 0)
            {
                _EnergyGreen = 0.1f;
            }

            if (_EnergyGreen >= _MaxEnergy)
            {
                _EnergyGreen = _MaxEnergy - 0.1f;
            }

            if (_EnergyRed <= 0)
            {
                _EnergyRed = 0.1f;
            }

            if (_EnergyRed >= _MaxEnergy)
            {
                _EnergyRed = _MaxEnergy - 0.1f;
            }
        }
    }
}