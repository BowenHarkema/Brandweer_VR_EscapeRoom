using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Energy_Manager : MonoBehaviour
{
    public static Energy_Manager current;

    [SerializeField]
    private float EnergyGreen;
    public float P_EnergyGreen { get { return EnergyGreen; } }

    [SerializeField]
    private float EnergyRed;
    public float P_EnergyRed { get { return EnergyRed; } }

    [Header("General settings")]
    [SerializeField]
    private int MaxEnergy;
    public int P_MaxEnergy { get { return MaxEnergy; } }

    [SerializeField]
    [Range(0, 50)]
    private int RaiseLowerStep;

    [Header("Settings for when energy is fixed")]
    [Tooltip("Hiermee kun je de range bepalen waarop de energy fixed moet zijn. Dit moet samen komen tot maxenergy")]
    [SerializeField]
    private int TargetEnergyRed;
    [SerializeField]
    private int TargetEnergyGreen;
    [SerializeField]
    private int DismissRange;


    private void Awake()
    {
        current = this;

        EnergyGreen = MaxEnergy / 2;
        EnergyRed = MaxEnergy / 2;
    }

    private void FixedUpdate()
    {
        if (EnergyGreen >= TargetEnergyGreen - DismissRange && EnergyGreen <= TargetEnergyGreen + DismissRange
            && EnergyRed >= TargetEnergyRed - DismissRange && EnergyRed <= TargetEnergyRed + DismissRange)
        {
            Debug.Log("Energy Fixed");
        }
    }

    public event Action OnLowerEnergyGreen;
    public void LowerEnergyGreen()
    {
        if (OnLowerEnergyGreen != null)
        {
            OnLowerEnergyGreen();

            if (EnergyGreen >= 0 && EnergyGreen <= MaxEnergy)
            {
                EnergyGreen -= RaiseLowerStep * Time.deltaTime;
            }

            if (EnergyRed >= 0 && EnergyRed <= MaxEnergy)
            {
                EnergyRed += RaiseLowerStep * Time.deltaTime;
            }

            if (EnergyGreen <= 0)
            {
                EnergyGreen = 0.1f;
            }

            if (EnergyGreen >= MaxEnergy)
            {
                EnergyGreen = MaxEnergy - 0.1f;
            }

            if (EnergyRed <= 0)
            {
                EnergyRed = 0.1f;
            }

            if (EnergyRed >= MaxEnergy)
            {
                EnergyRed = MaxEnergy - 0.1f;
            }
        }
    }

    public event Action OnLowerEnergyRed;
    public void LowerEnergyRed()
    {
        if (OnLowerEnergyRed != null)
        {
            OnLowerEnergyRed();
            if (EnergyGreen >= 0 && EnergyGreen <= MaxEnergy)
            {
                EnergyGreen += RaiseLowerStep * Time.deltaTime;
            }

            if (EnergyRed >= 0 && EnergyRed <= MaxEnergy)
            {
                EnergyRed -= RaiseLowerStep * Time.deltaTime;
            }

            if (EnergyGreen <= 0)
            {
                EnergyGreen = 0.1f;
            }

            if (EnergyGreen >= MaxEnergy)
            {
                EnergyGreen = MaxEnergy - 0.1f;
            }

            if (EnergyRed <= 0)
            {
                EnergyRed = 0.1f;
            }

            if (EnergyRed >= MaxEnergy)
            {
                EnergyRed = MaxEnergy - 0.1f;
            }
        }
    }
}
