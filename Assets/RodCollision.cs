using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodCollision : MonoBehaviour

{
    [SerializeField] public string rodNameSetter;
    [SerializeField] private List<GameObject> Rods;
    [SerializeField] private GameObject coreSphere;

    [SerializeField] private string rightSequence;
    [SerializeField] private string currentSequence;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void action()
    {

        switch (rodNameSetter)
        {
            case "1a":
                currentSequence += 11;
                rodNameSetter = "";
                break;
            case "1b":
                currentSequence += 12;
                rodNameSetter = "";
                break;
            case "1c":
                currentSequence += 13;
                rodNameSetter = "";
                break;
            case "1d":
                currentSequence += 14;
                rodNameSetter = "";
                break;
            case "1e":
                currentSequence += 15;
                rodNameSetter = "";
                break;
            case "1f":
                currentSequence += 16;
                rodNameSetter = "";
                break;
            case "2a":
                currentSequence += 21;
                rodNameSetter = "";
                break;
            case "2b":
                currentSequence += 22;
                rodNameSetter = "";
                break;
            case "2c":
                currentSequence += 23;
                rodNameSetter = "";
                break;
            case "2d":
                currentSequence += 24;
                rodNameSetter = "";
                break;
            case "2e":
                currentSequence += 25;
                rodNameSetter = "";
                break;
            case "2f":
                currentSequence += 26;
                rodNameSetter = "";
                break;
            case "3a":
                currentSequence += 31;
                rodNameSetter = "";
                break;
            case "3b":
                currentSequence += 32;
                rodNameSetter = "";
                break;
            case "3c":
                currentSequence += 33;
                rodNameSetter = "";
                break;
            case "3d":
                currentSequence += 34;
                rodNameSetter = "";
                break;
            case "3e":
                currentSequence += 35;
                rodNameSetter = "";
                break;
            case "3f":
                currentSequence += 36;
                rodNameSetter = "";
                break;
        }
    }
}
