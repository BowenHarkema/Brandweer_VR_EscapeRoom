using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GeneratorSync : MonoBehaviour
{
    [SerializeField] private int _generatorUpCount;
    //wordt niet gebruikt, misschien als je de progressie ergens wil laten tonen
    public int GeneratorUpCount { get { return _generatorUpCount; } set { _generatorUpCount = value; } }

    public UnityEvent AllGeneratorsUp = new UnityEvent();
    public TextMeshProUGUI generatorUpText;

    // Update is called once per frame
    void Update()
    {
        //checks if all generators are up and then calls a unity event
        if(_generatorUpCount == 5)
            AllGeneratorsUp.Invoke();
    }

    //event that gets called when powercell is inserted into generator
    public void generatorUp()
    {
        if (_generatorUpCount < 5)
        {
            _generatorUpCount++;
            generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/5";
        }
    }
}
