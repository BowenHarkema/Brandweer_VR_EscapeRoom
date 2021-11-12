using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GeneratorSync : MonoBehaviour
{
    [SerializeField] private int _GeneratorUpCount;
    public int P_GeneratorUpCount { get { return _GeneratorUpCount; } set { _GeneratorUpCount = value; } }
    public TextMeshProUGUI generatorUpText;

    public UnityEvent GeneratorsEvent = new UnityEvent();

    //event that gets called when powercell is inserted into generator
    public void generatorUp()
    {
        if (_GeneratorUpCount < 5)
        {
            _GeneratorUpCount++;
            generatorUpText.text = $"Werkende generators: {_GeneratorUpCount.ToString()}/5";
        }
        else if (_GeneratorUpCount == 5)
        {
            GeneratorsEvent.Invoke();
        }
    }
}
