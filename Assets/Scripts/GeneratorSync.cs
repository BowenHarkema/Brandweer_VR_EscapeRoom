using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Photon.Pun;

public class GeneratorSync : MonoBehaviourPunCallbacks
{
    [SerializeField] private int _generatorUpCount;
    [SerializeField] private bool _gen1Up;
    [SerializeField] private bool _gen2Up;
    [SerializeField] private bool _gen3Up;
    [SerializeField] private bool _gen4Up;
    public int P_GeneratorUpCount { get { return _generatorUpCount; } set { _generatorUpCount = value; } }
    public TextMeshProUGUI generatorUpText;

    [SerializeField] private ExitGames.Client.Photon.Hashtable _GenCountProp = new ExitGames.Client.Photon.Hashtable();

    [SerializeField] private ProgressManager _ProgressManager;

    private void Start()
    {
        _GenCountProp["GenCount"] = _generatorUpCount;
        _GenCountProp["Gen1Up"] = _gen1Up;
        _GenCountProp["Gen2Up"] = _gen2Up;
        _GenCountProp["Gen3Up"] = _gen3Up;
        _GenCountProp["Gen4Up"] = _gen4Up;

        PhotonNetwork.CurrentRoom.SetCustomProperties(_GenCountProp);
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable property)
    {
        Debug.Log(property);
        if (property.ContainsKey("GenCount"))
        {
            _generatorUpCount = (int)PhotonNetwork.CurrentRoom.CustomProperties["GenCount"];
            generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/4";
            Debug.Log("property changed: " + _GenCountProp);
        }
        if (property.ContainsKey("Gen1Up"))
        {
            _gen1Up = (bool)PhotonNetwork.CurrentRoom.CustomProperties["Gen1Up"];
            Debug.Log("property changed: " + _GenCountProp);
        }
        if (property.ContainsKey("Gen2Up"))
        {
            _gen2Up = (bool)PhotonNetwork.CurrentRoom.CustomProperties["Gen2Up"];
            Debug.Log("property changed: " + _GenCountProp);
        }
        if (property.ContainsKey("Gen3Up"))
        {
            _gen3Up = (bool)PhotonNetwork.CurrentRoom.CustomProperties["Gen3Up"];
            Debug.Log("property changed: " + _GenCountProp);
        }
        if (property.ContainsKey("Gen4Up"))
        {
            _gen4Up = (bool)PhotonNetwork.CurrentRoom.CustomProperties["Gen4Up"];
            Debug.Log("property changed: " + _GenCountProp);
        }
    }
    //event that gets called when powercell is inserted into generator
    public void generatorUp(int genNumber)
    {
        if (_generatorUpCount <= 4)
        {
            switch (genNumber)
            {
                case 1:
                    if (!_gen1Up)
                    {
                        _gen1Up = true;
                        _generatorUpCount++;
                        _GenCountProp["GenCount"] = _generatorUpCount;
                        _GenCountProp["Gen1Up"] = _gen1Up;
                        PhotonNetwork.CurrentRoom.SetCustomProperties(_GenCountProp);
                        generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/4";
                    }
                    break;
                case 2:
                    if (!_gen2Up)
                    {
                        _gen2Up = true;
                        _generatorUpCount++;
                        _GenCountProp["GenCount"] = _generatorUpCount;
                        _GenCountProp["Gen2Up"] = _gen2Up;
                        PhotonNetwork.CurrentRoom.SetCustomProperties(_GenCountProp);
                        generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/4";
                    }
                    break;
                case 3:
                    if (!_gen3Up)
                    {
                        _gen3Up = true;
                        _generatorUpCount++;
                        _GenCountProp["GenCount"] = _generatorUpCount;
                        _GenCountProp["Gen3Up"] = _gen3Up;
                        PhotonNetwork.CurrentRoom.SetCustomProperties(_GenCountProp);
                        generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/4";
                    }
                    break;
                case 4:
                    if (!_gen4Up)
                    {
                        _gen4Up = true;
                        _generatorUpCount++;
                        _GenCountProp["GenCount"] = _generatorUpCount;
                        _GenCountProp["Gen4Up"] = _gen4Up;
                        PhotonNetwork.CurrentRoom.SetCustomProperties(_GenCountProp);
                        generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/4";
                    }
                    break;
            }
        }
        if (_generatorUpCount >= 4)
        {
            _ProgressManager.RoomFixed(1);
        }
    }
}
