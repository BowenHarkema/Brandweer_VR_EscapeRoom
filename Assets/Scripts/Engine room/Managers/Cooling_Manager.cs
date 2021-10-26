using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cooling_Manager : MonoBehaviour
{
    public static Cooling_Manager current;

    [SerializeField]
    private float CoolingGreen;
    public float P_CoolingGreen { get { return CoolingGreen; } }

    [SerializeField]
    private float CoolingRed;
    public float P_CoolingRed { get { return CoolingRed; } }

    [Header("General settings")]
    [SerializeField]
    private int MaxCooling;
    public int P_MaxCooling { get { return MaxCooling; } }

    [SerializeField] [Range(0,50)]
    private int RaiseLowerStep;

    [Header("Settings for when cooling is fixed")] [Tooltip("Hiermee kun je de range bepalen waarop de cooling fixed moet zijn. Dit moet samen komen tot maxcooling")]
    [SerializeField]
    private int TargetCoolingRed;
    [SerializeField]
    private int TargetCoolingGreen;
    [SerializeField]    
    private int DismissRange;


    private void Awake()
    {
        current = this;

        CoolingGreen = MaxCooling / 2;
        CoolingRed = MaxCooling / 2;
    }

    private void FixedUpdate()
    {
        if(CoolingGreen >= TargetCoolingGreen - DismissRange && CoolingGreen <= TargetCoolingGreen + DismissRange 
            && CoolingRed >= TargetCoolingRed - DismissRange && CoolingRed <= TargetCoolingRed + DismissRange )
        {
            Debug.Log("Cooling Fixed");
        }

        Mathf.Clamp(CoolingGreen, 0.1f, MaxCooling);
        Mathf.Clamp(CoolingRed, 0.1f, MaxCooling);

    }

    public event Action OnLowerCoolingGreen;
    public void LowerCoolingGreen()
    {
        if (OnLowerCoolingGreen != null)
        {
            OnLowerCoolingGreen();

            if(CoolingGreen >= 0 && CoolingGreen <= MaxCooling)
            {
                CoolingGreen -= RaiseLowerStep * Time.deltaTime;
            }

            if (CoolingRed >= 0 && CoolingRed <= MaxCooling)
            {
                CoolingRed += RaiseLowerStep * Time.deltaTime;
            }

            if (CoolingGreen <= 0) {
                CoolingGreen = 0.1f; }

            if (CoolingGreen >= MaxCooling) {
                CoolingGreen = MaxCooling - 0.1f; }

            if (CoolingRed <= 0) {
                CoolingRed = 0.1f; }

            if (CoolingRed >= MaxCooling) {
                CoolingRed = MaxCooling - 0.1f; }
        }
    }

    public event Action OnLowerCoolingRed;
    public void LowerCoolingRed()
    {
        if (OnLowerCoolingRed != null)
        {
            OnLowerCoolingRed();
            if (CoolingGreen >= 0 && CoolingGreen <= MaxCooling)
            {
                CoolingGreen += RaiseLowerStep * Time.deltaTime;
            }

            if (CoolingRed >= 0 && CoolingRed <= MaxCooling)
            {
                CoolingRed -= RaiseLowerStep * Time.deltaTime;
            }

            if (CoolingGreen <= 0) {
                CoolingGreen = 0.1f; }

            if (CoolingGreen >= MaxCooling) {
                CoolingGreen = MaxCooling - 0.1f; }

            if (CoolingRed <= 0) {
                CoolingRed = 0.1f; }

            if (CoolingRed >= MaxCooling) {
                CoolingRed = MaxCooling - 0.1f; }
        }
    }
}
