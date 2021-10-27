using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Energy_Manager : MonoBehaviour
{
    public static Energy_Manager _Current;

    [SerializeField]
    private float _EnergyGreen;
    public float P_EnergyGreen { get { return _EnergyGreen; } }

    [SerializeField]
    private float _EnergyRed;
    public float P_EnergyRed { get { return _EnergyRed; } }

    [Header("General settings")]
    [SerializeField]
    private int _MaxEnergy;
    public int P_MaxEnergy { get { return _MaxEnergy; } }

    [SerializeField]
    [Range(0, 50)]
    private int _RaiseLowerStep;

    [Header("Settings for when energy is fixed")]
    [Tooltip("Hiermee kun je de range bepalen waarop de energy fixed moet zijn. Dit moet samen komen tot maxenergy")]
    [SerializeField]
    private int _TargetEnergyRed;
    [SerializeField]
    private int _TargetEnergyGreen;
    [SerializeField]
    private int _DismissRange;

    //Set the manager as singleton item.
    private void Awake()
    {
        _Current = this;

        _EnergyGreen = _MaxEnergy / 2;
        _EnergyRed = _MaxEnergy / 2;
    }

    //Fixed update to check data and fix items.
    private void FixedUpdate()
    {
        if (_EnergyGreen >= _TargetEnergyGreen - _DismissRange && _EnergyGreen <= _TargetEnergyGreen + _DismissRange
            && _EnergyRed >= _TargetEnergyRed - _DismissRange && _EnergyRed <= _TargetEnergyRed + _DismissRange)
        {
            Debug.Log("Energy Fixed");
        }
    }

    //event and function for manager.
    public event Action OnLowerEnergyGreen;
    public void LowerEnergyGreen()
    {
        if (OnLowerEnergyGreen != null)
        {
            OnLowerEnergyGreen();

            if (_EnergyGreen >= 0 && _EnergyGreen <= _MaxEnergy)
            {
                _EnergyGreen -= _RaiseLowerStep * Time.deltaTime;
            }

            if (_EnergyRed >= 0 && _EnergyRed <= _MaxEnergy)
            {
                _EnergyRed += _RaiseLowerStep * Time.deltaTime;
            }

            if (_EnergyGreen <= 0)
            {
                _EnergyGreen = 0.1f;
            }

            if (_EnergyGreen >= _MaxEnergy)
            {
                _EnergyGreen = _MaxEnergy - 0.1f;
            }

            if (_EnergyRed <= 0)
            {
                _EnergyRed = 0.1f;
            }

            if (_EnergyRed >= _MaxEnergy)
            {
                _EnergyRed = _MaxEnergy - 0.1f;
            }
        }
    }

    //event and function for manager.
    public event Action OnLowerEnergyRed;
    public void LowerEnergyRed()
    {
        if (OnLowerEnergyRed != null)
        {
            OnLowerEnergyRed();
            if (_EnergyGreen >= 0 && _EnergyGreen <= _MaxEnergy)
            {
                _EnergyGreen += _RaiseLowerStep * Time.deltaTime;
            }

            if (_EnergyRed >= 0 && _EnergyRed <= _MaxEnergy)
            {
                _EnergyRed -= _RaiseLowerStep * Time.deltaTime;
            }

            if (_EnergyGreen <= 0)
            {
                _EnergyGreen = 0.1f;
            }

            if (_EnergyGreen >= _MaxEnergy)
            {
                _EnergyGreen = _MaxEnergy - 0.1f;
            }

            if (_EnergyRed <= 0)
            {
                _EnergyRed = 0.1f;
            }

            if (_EnergyRed >= _MaxEnergy)
            {
                _EnergyRed = _MaxEnergy - 0.1f;
            }
        }
    }
}
