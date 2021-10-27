using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainEnginePanel : MonoBehaviour
{

    [SerializeField]
    private bool _ABool, _BBool, _CBool, _DBool;

    [SerializeField]
    private Text _Redroom_Sequence_Text, _Greenroom_Sequence_Text;

    [SerializeField]
    private StartSystemManager _SM;

    //Subscibe to event system of manager.
    void Start()
    {
        StartSystemManager._Current.OnAbutton += OnAbutton;
        StartSystemManager._Current.OnBbutton += OnBbutton;
        StartSystemManager._Current.OnCbutton += OnCbutton;
        StartSystemManager._Current.OnDbutton += OnDbutton;
    }

    //function for update data and checking values
    private void FixedUpdate()
    {
        if (_ABool)
        {
            StartSystemManager._Current.Abutton();
        }
        if (_BBool)
        {
            StartSystemManager._Current.Bbutton();
        }
        if (_CBool)
        {
            StartSystemManager._Current.Cbutton();
        }
        if (_DBool)
        {
            StartSystemManager._Current.Dbutton();
        }

        _Redroom_Sequence_Text.text = "sequence: " + StartSystemManager._Current.P_Current_sequence_Order;
        _Greenroom_Sequence_Text.text = "sequence: " + StartSystemManager._Current.P_Current_sequence_Order;

    }

    //Functions to set boolean so we dont use event functions
    public void SetABool(bool i)
    {
        _ABool = i;
    }
    public void SetBBool(bool i)
    {
        _BBool = i;
    }
    public void SetCBool(bool i)
    {
        _CBool = i;
    }
    public void SetDBool(bool i)
    {
        _DBool = i;
    }

    //Function to execute code when event is called
    private void OnAbutton()
    {
        Debug.Log("Added A");
    }
    private void OnBbutton()
    {
        Debug.Log("Added B");
    }
    private void OnCbutton()
    {
        Debug.Log("Added C");
    }
    private void OnDbutton()
    {
        Debug.Log("Added D");
    }

    //Unsub from event functions when object gets destroyed to avoid NULL pointers
    private void OnDestroy()
    {
        StartSystemManager._Current.OnAbutton -= OnAbutton;
        StartSystemManager._Current.OnBbutton -= OnBbutton;
        StartSystemManager._Current.OnCbutton -= OnCbutton;
        StartSystemManager._Current.OnDbutton -= OnDbutton;
    }
}
