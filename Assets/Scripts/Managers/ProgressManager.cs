using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    [SerializeField] private GeneratorSync _GeneratorSync;
    [SerializeField] private Plant_pods_controller _PlantPodsController;
    [SerializeField] private bool _AllGeneratorsUp;
    [SerializeField] private bool _AllPodsBalanced;

    // Update is called once per frame
    void Update()
    {
        _AllGeneratorsUp = _GeneratorSync.GeneratorUpCount == 5 ? true : false;
        _AllPodsBalanced = _PlantPodsController.getBrokenPods() == 0 ? true : false;
        //if bools are true call events to happen
    }
}
