using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GeneratorSync _GeneratorSync;
    [SerializeField] private Plant_pods_controller _PlantPodsController;
    [SerializeField] private bool _AllGeneratorsUp;
    [SerializeField] private bool _AllPodsBalanced;

    [SerializeField] private ExitGames.Client.Photon.Hashtable _MyCustomProperties = new ExitGames.Client.Photon.Hashtable();

    // Update is called once per frame
    void Update()
    {
        _AllGeneratorsUp = _GeneratorSync.GeneratorUpCount == 5 ? true : false;
        _AllPodsBalanced = _PlantPodsController.getBrokenPods() == 0 ? true : false;

        _MyCustomProperties["Generators"] = _AllGeneratorsUp;
        _MyCustomProperties["PlantPods"] = _AllGeneratorsUp;
        PhotonNetwork.LocalPlayer.CustomProperties = _MyCustomProperties;

        //check if customproperty is true, then call event
    }
}
