using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class ChangeCamera : MonoBehaviour
{
    public UnityEvent onPressed, onReleased;

    [SerializeField] private float threshold = 0.01f;
    [SerializeField] private float deadZone = 0.025f;

 
    [SerializeField] private bool _isPressed;
    [SerializeField] private bool _SideCam;
    [SerializeField] private bool _TopCam;
    [SerializeField] private Vector3 _startPos;
    [SerializeField] public GameObject _Canvas;
    [SerializeField] private RenderTexture _Camera1;
    [SerializeField] private RenderTexture _Camera2;
    [SerializeField] private ConfigurableJoint _joint;
    [SerializeField] private Rigidbody _rb;

    void Start()
    {
 
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();

    }

    void Update()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
        {
            Pressed();
        }

        if (_isPressed && GetValue() - threshold <= 0)
        {


            Released();
        }

    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Math.Abs(value) < deadZone)
            
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);
        
    }

    private void Pressed()
    {
        if(_SideCam == true)
        {
            _Canvas.GetComponent<ScreenSwitcher>().cam1 = true;
            _Canvas.GetComponent<ScreenSwitcher>().cam2 = false;

        }
        if(_TopCam == true)
        {
            _Canvas.GetComponent<ScreenSwitcher>().cam2 = true;
            _Canvas.GetComponent<ScreenSwitcher>().cam1 = false;

        }

    }

    private void Released()
    {
        _isPressed = false;
        
        print("release button");

    }
 
    /*private void ChangeCam()
    {
        if(_SideCam ==true)
        {
            _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera2;
            print("pressed camerachange to SideCam");
            
        }
        else
        {
            _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera1;

            print("pressed camerachange to TopCam");
            
        }
        
    }*/

}
