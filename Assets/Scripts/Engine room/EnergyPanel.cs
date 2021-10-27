using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyPanel : MonoBehaviour
{
    [SerializeField]
    private bool _LowerinBool, _HigheringBool;

    [SerializeField]
    private Text _Greenroom_Energy_Text, _Redroom_Energy_Text;

    [SerializeField]
    private Energy_Manager _EM;

    //Subscibe to event system of manager.
    void Start()
    {
        Energy_Manager._Current.OnLowerEnergyGreen += OnLowerEnergyGreen;
        Energy_Manager._Current.OnLowerEnergyRed += OnLowerEnergyRed;
    }

    //function for update data and checking values
    private void Update()
    {
        if (_LowerinBool)
        {
            Energy_Manager._Current.LowerEnergyGreen();
        }
        if (_HigheringBool)
        {
            Energy_Manager._Current.LowerEnergyRed();
        }

        _Greenroom_Energy_Text.text = "Energy level: " + Mathf.RoundToInt(Energy_Manager._Current.P_EnergyGreen);
        _Redroom_Energy_Text.text = "Energy level: " + Mathf.RoundToInt(Energy_Manager._Current.P_EnergyRed);
    }

    //Functions to set boolean so we dont use event functions
    public void Setlowerbool(bool i)
    {
        _LowerinBool = i;
    }
    public void Sethigherbool(bool i)
    {
        _HigheringBool = i;
    }

    //Function to execute code when event is called
    private void OnLowerEnergyGreen()
    {
        Debug.Log("lowering green, Raising Red");
    }
    private void OnLowerEnergyRed()
    {
        Debug.Log("lowering Red, Raising Green");
    }

    //Unsub from event functions when object gets destroyed to avoid NULL pointers
    private void OnDestroy()
    {
        Energy_Manager._Current.OnLowerEnergyGreen -= OnLowerEnergyGreen;
        Energy_Manager._Current.OnLowerEnergyRed -= OnLowerEnergyRed;
    }
}
