using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GeneratorSync _GeneratorSync;
    [SerializeField] private Plant_pods_controller _PlantPodsController;
    [SerializeField] private bool _AllGeneratorsUp;
    [SerializeField] private bool _AllPodsBalanced;

    [SerializeField] private ExitGames.Client.Photon.Hashtable _MyCustomProperties = new ExitGames.Client.Photon.Hashtable();

    public UnityEvent GeneratorsEvent = new UnityEvent();
    public UnityEvent PlantPodsEvent = new UnityEvent();
    private bool _IsCalled = false;

    // Update is called once per frame
    void Update()
    {
        //checks if generators are all up and if plant pods are all balanced
        _AllGeneratorsUp = _GeneratorSync.P_GeneratorUpCount == 5 ? true : false;
        _AllPodsBalanced = _PlantPodsController.getBrokenPods() == 0 ? true : false;

        //set the custom properties for generators and plantpods
        _MyCustomProperties["Generators"] = _AllGeneratorsUp;
        _MyCustomProperties["PlantPods"] = _AllPodsBalanced;
        PhotonNetwork.LocalPlayer.CustomProperties = _MyCustomProperties;

        if(_AllGeneratorsUp == true && _AllPodsBalanced == true)
            GeneratorAndPodsEvent();
    }

    //Unity events that are called as soon as generators are up and pods are balanced
    private void GeneratorAndPodsEvent()
    {
        _IsCalled = true;
        if (!_IsCalled)
        {
            GeneratorsEvent.Invoke();
            PlantPodsEvent.Invoke();
        }
    }
}
