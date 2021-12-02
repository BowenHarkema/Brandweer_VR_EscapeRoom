using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Photon.Pun;

public class GeneratorSync : MonoBehaviour
{
    [SerializeField] private int _generatorUpCount;
    public int P_GeneratorUpCount { get { return _generatorUpCount; } set { _generatorUpCount = value; } }
    public TextMeshProUGUI generatorUpText;

    [SerializeField] private ExitGames.Client.Photon.Hashtable _GenCountProp = new ExitGames.Client.Photon.Hashtable();

    private void Start()
    {
        _GenCountProp["GenCount"] = _generatorUpCount;
        PhotonNetwork.CurrentRoom.SetCustomProperties(_GenCountProp);
    }

    //event that gets called when powercell is inserted into generator
    public void generatorUp()
    {
        if (_generatorUpCount <= 5)
        {
            _generatorUpCount++;
            _GenCountProp["GenCount"] = _generatorUpCount;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_GenCountProp);
            generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/5";
        }
    }
}
