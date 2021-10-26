using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyPanel : MonoBehaviour
{
    [SerializeField]
    private bool testbool, testbool2;

    [SerializeField]
    private Text GreenRoomText, RedRoomText;

    [SerializeField]
    private Energy_Manager em;

    void Start()
    {
        Energy_Manager.current.OnLowerEnergyGreen += OnLowerEnergyGreen;
        Energy_Manager.current.OnLowerEnergyRed += OnLowerEnergyRed;
    }

    private void Update()
    {
        if (testbool)
        {
            Energy_Manager.current.LowerEnergyGreen();
        }
        if (testbool2)
        {
            Energy_Manager.current.LowerEnergyRed();
        }

        GreenRoomText.text = "Energy level: " + Mathf.RoundToInt(Energy_Manager.current.P_EnergyGreen);
        RedRoomText.text = "Energy level: " + Mathf.RoundToInt(Energy_Manager.current.P_EnergyRed);
    }

    public void Setlowerbool(bool i)
    {
        testbool = i;
    }

    public void Sethigherbool(bool i)
    {
        testbool2 = i;
    }

    private void OnLowerEnergyGreen()
    {
        Debug.Log("lowering green, Raising Red");
    }

    private void OnLowerEnergyRed()
    {
        Debug.Log("lowering Red, Raising Green");
    }

    private void OnDestroy()
    {
        Energy_Manager.current.OnLowerEnergyGreen -= OnLowerEnergyGreen;
        Energy_Manager.current.OnLowerEnergyRed -= OnLowerEnergyRed;
    }
}
