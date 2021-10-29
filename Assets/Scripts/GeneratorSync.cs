﻿using System.Collections;
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
        //checkt of alle generators up zijn en called dan een event wat de deuren opent naar reactor
        if(_generatorUpCount == 5)
            AllGeneratorsUp.Invoke();
    }

    //event dat wordt aangeroepen zodra een powercell in een generator wordt geladen
    public void generatorUp()
    {
        if (_generatorUpCount < 5)
        {
            _generatorUpCount++;
            generatorUpText.text = $"Werkende generators: {_generatorUpCount.ToString()}/5";
        }
    }
}
