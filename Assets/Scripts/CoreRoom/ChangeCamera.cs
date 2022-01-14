using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private bool _Switcher;

    [SerializeField] public GameObject _Canvas;
    [SerializeField] private RenderTexture _Camera1;
    [SerializeField] private RenderTexture _Camera2;

    [SerializeField] private Rigidbody _rb; 

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "ButtonBase" && _Switcher == true)
        {
            _Switcher = false;
            _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera2;
        }
        else if (collider.gameObject.tag == "ButtonBase" && _Switcher == false)
        {
            _Switcher = true;
            _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera1;
        }

        print("release button");

    }
 


}
