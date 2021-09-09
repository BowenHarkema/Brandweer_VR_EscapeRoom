using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigthScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableLights(){
        Debug.Log("Lights on");
        
        Light[] ligths = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light ligth in ligths) {
            ligth.enabled = true;
        }
    }
    public void DisableLights(){
        Debug.Log("Lights off");

        Light[] ligths = FindObjectsOfType(typeof(Light)) as Light[];
        foreach (Light ligth in ligths) {
            ligth.enabled = false;
        }
    }
}
