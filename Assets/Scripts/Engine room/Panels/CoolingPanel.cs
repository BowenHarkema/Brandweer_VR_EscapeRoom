using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoolingPanel : MonoBehaviour
{
    [SerializeField]
    public bool _LoweringBool, _HigheringBool;

    [SerializeField]
    private TextMeshProUGUI _Greenroom_Cooling_Text, _Redroom_Cooling_Text;

    [SerializeField]
    private Cooling_Manager _CM;

    //Subscibe to event system of manager.
    void Start()
    {
        Cooling_Manager.current.OnLowerCoolingGreen += OnLowerCoolingGreen;
        Cooling_Manager.current.OnLowerCoolingRed += OnLowerCoolingRed;
    }

    //function for update data and checking values
    private void Update()
    {
        if(_LoweringBool)
        {
            Cooling_Manager.current.LowerCoolingGreen();
        }
        if (_HigheringBool)
        {
            Cooling_Manager.current.LowerCoolingRed();
        }

        if(_Greenroom_Cooling_Text.enabled)
        {
            _Greenroom_Cooling_Text.text = "Cooling level: " + Mathf.RoundToInt(Cooling_Manager.current.P_CoolingGreen);
        }

        if(_Redroom_Cooling_Text.enabled)
        {
            _Redroom_Cooling_Text.text = "Cooling level: " + Mathf.RoundToInt(Cooling_Manager.current.P_CoolingRed);
        }
    }

    //Functions to set boolean so we dont use event functions
    public void Setlowerbool(bool i)
    {
        _LoweringBool = i;
    }
    public void Sethigherbool(bool i)
    {
        _HigheringBool = i;
    }

    //Function to execute code when event is called
    private void OnLowerCoolingGreen()
    {
        Debug.Log("lowering green, Raising Red");
    }
    private void OnLowerCoolingRed()
    {
        Debug.Log("lowering Red, Raising Green");
    }

    //Unsub from event functions when object gets destroyed to avoid NULL pointers
    private void OnDestroy()
    {
        Cooling_Manager.current.OnLowerCoolingGreen -= OnLowerCoolingGreen;
        Cooling_Manager.current.OnLowerCoolingRed -= OnLowerCoolingRed;
    }
}
