using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolingPanel : MonoBehaviour
{
    [SerializeField]
    public bool testbool, testbool2;

    [SerializeField]
    private Text GreenRoomText, RedRoomText;

    [SerializeField]
    private Cooling_Manager cm;

    void Start()
    {
        Cooling_Manager.current.OnLowerCoolingGreen += OnLowerCoolingGreen;
        Cooling_Manager.current.OnLowerCoolingRed += OnLowerCoolingRed;
    }

    private void Update()
    {
        if(testbool)
        {
            Cooling_Manager.current.LowerCoolingGreen();
        }
        if (testbool2)
        {
            Cooling_Manager.current.LowerCoolingRed();
        }

        GreenRoomText.text = "Cooling level: " + Mathf.RoundToInt(Cooling_Manager.current.P_CoolingGreen);
        RedRoomText.text = "Cooling level: " + Mathf.RoundToInt(Cooling_Manager.current.P_CoolingRed);
    }

    public void Setlowerbool(bool i)
    {
        testbool = i;
    }

    public void Sethigherbool(bool i)
    {
        testbool2 = i;
    }

    private void OnLowerCoolingGreen()
    {
        Debug.Log("lowering green, Raising Red");
    }

    private void OnLowerCoolingRed()
    {
        Debug.Log("lowering Red, Raising Green");
    }

    private void OnDestroy()
    {
        Cooling_Manager.current.OnLowerCoolingGreen -= OnLowerCoolingGreen;
        Cooling_Manager.current.OnLowerCoolingRed -= OnLowerCoolingRed;
    }
}
