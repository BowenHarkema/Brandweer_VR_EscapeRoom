using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RodHandler : MonoBehaviour
{
    [SerializeField] public string rodNameSetter;
    [SerializeField] private List<GameObject> Rods;
    [SerializeField] private GameObject coreSphere;
    [SerializeField] private ParticleSystem coreSmoke;

    [SerializeField] private string rightSequence;
    [SerializeField] private string currentSequence;

    public UnityEvent WrongSeq;
    
    private void Start()
    {
        rightSequence = "112131";
        currentSequence = "";
    }
    private void Update()
    {
        if (rodNameSetter != "")
        {
            coreSphere.GetComponent<Light>().color = Color.blue;
            coreSmoke.GetComponent<ParticleSystem>().startColor = Color.blue;
            AddRodToSequence(rodNameSetter);
            
        }
     
    }

    //switch case met de corresponderende rod code die naar de currentsequence schrijft
    void AddRodToSequence(string rodNumber)
    {
        switch (rodNumber)
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
        //kijkt op de currentsequence niet hetzelfde is als de rightsequence lengte van de currentsequence
        //zo nee start de functie wrongsequence
        if (currentSequence != rightSequence.Substring(0, currentSequence.Length))
        {
            currentSequence = "";
            coreSphere.GetComponent<Light>().color = Color.red;
            coreSmoke.GetComponent<ParticleSystem>().startColor = Color.red;
            wrongSequence();
            print("lekker man nu is alles kapot");
            
        }
        else if (currentSequence == rightSequence)
        {
            
            currentSequence = "";
            coreSphere.GetComponent<Light>().color = Color.green;
            coreSmoke.GetComponent<ParticleSystem>().startColor = Color.green;
            print("core is stabiel");
        }
    }
    //maakt een objarray met alle rods, gaat vervolgens per array de rigidbody terug zetten
    //de boolean is pressed terug zetten naar false
    //en het script ResetPosition starten in het script van de rods
    void wrongSequence()
    {
        rodNameSetter = "";
        
        foreach(GameObject rod in Rods)
        {
            rod.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            CoreRodController script = rod.GetComponent<CoreRodController>();
            script.isPressed = false;
            script.ResetPosition();
            
        }


    }


}
