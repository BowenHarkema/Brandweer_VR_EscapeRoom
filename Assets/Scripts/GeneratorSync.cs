using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GeneratorSync : MonoBehaviour
{
    [SerializeField] private int _generatorUpCount;
    public int GeneratorUpCount { get { return _generatorUpCount; } set { _generatorUpCount = value; } }
    public TextMeshProUGUI generatorUpText;

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
