using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cooling_Manager : MonoBehaviour
{
    public static Cooling_Manager current;

    [SerializeField]
    private float _CoolingGreen;
    public float P_CoolingGreen { get { return _CoolingGreen; } }

    [SerializeField]
    private float _CoolingRed;
    public float P_CoolingRed { get { return _CoolingRed; } }

    [Header("General settings")]
    [SerializeField]
    private int _MaxCooling;
    public int P_MaxCooling { get { return _MaxCooling; } }

    [SerializeField] [Range(0,50)]
    private int _RaiseLowerStep;

    [Header("Settings for when cooling is fixed")] [Tooltip("Hiermee kun je de range bepalen waarop de cooling fixed moet zijn. Dit moet samen komen tot maxcooling")]
    [SerializeField]
    private int _TargetCoolingRed;
    [SerializeField]
    private int _TargetCoolingGreen;
    [SerializeField]    
    private int _DismissRange;

    //Set the manager as singleton item. and divide target cooling value to half
    private void Awake()
    {
        current = this;

        _CoolingGreen = _MaxCooling / 2;
        _CoolingRed = _MaxCooling / 2;
    }

    //Fixed update to check data and fix items.
    private void FixedUpdate()
    {
        if(_CoolingGreen >= _TargetCoolingGreen - _DismissRange && _CoolingGreen <= _TargetCoolingGreen + _DismissRange 
            && _CoolingRed >= _TargetCoolingRed - _DismissRange && _CoolingRed <= _TargetCoolingRed + _DismissRange )
        {
            Debug.Log("Cooling Fixed");
        }

        Mathf.Clamp(_CoolingGreen, 0.1f, _MaxCooling);
        Mathf.Clamp(_CoolingRed, 0.1f, _MaxCooling);

    }

    //event and function for manager.
    public event Action OnLowerCoolingGreen;
    public void LowerCoolingGreen()
    {
        if (OnLowerCoolingGreen != null)
        {
            OnLowerCoolingGreen();

            if(_CoolingGreen >= 0 && _CoolingGreen <= _MaxCooling)
            {
                _CoolingGreen -= _RaiseLowerStep * Time.deltaTime;
            }

            if (_CoolingRed >= 0 && _CoolingRed <= _MaxCooling)
            {
                _CoolingRed += _RaiseLowerStep * Time.deltaTime;
            }

            if (_CoolingGreen <= 0) {
                _CoolingGreen = 0.1f; }

            if (_CoolingGreen >= _MaxCooling) {
                _CoolingGreen = _MaxCooling - 0.1f; }

            if (_CoolingRed <= 0) {
                _CoolingRed = 0.1f; }

            if (_CoolingRed >= _MaxCooling) {
                _CoolingRed = _MaxCooling - 0.1f; }
        }
    }

    //event and function for manager.
    public event Action OnLowerCoolingRed;
    public void LowerCoolingRed()
    {
        if (OnLowerCoolingRed != null)
        {
            OnLowerCoolingRed();
            if (_CoolingGreen >= 0 && _CoolingGreen <= _MaxCooling)
            {
                _CoolingGreen += _RaiseLowerStep * Time.deltaTime;
            }

            if (_CoolingRed >= 0 && _CoolingRed <= _MaxCooling)
            {
                _CoolingRed -= _RaiseLowerStep * Time.deltaTime;
            }

            if (_CoolingGreen <= 0) {
                _CoolingGreen = 0.1f; }

            if (_CoolingGreen >= _MaxCooling) {
                _CoolingGreen = _MaxCooling - 0.1f; }

            if (_CoolingRed <= 0) {
                _CoolingRed = 0.1f; }

            if (_CoolingRed >= _MaxCooling) {
                _CoolingRed = _MaxCooling - 0.1f; }
        }
    }
}
