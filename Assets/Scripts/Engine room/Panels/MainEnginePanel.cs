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
    private void Update()
    {
        string temp = "Sequence: " + StartSystemManager._Current.P_Current_sequence_Order.ToString();
        _Redroom_Sequence_Text.text = temp;
        _Greenroom_Sequence_Text.text = temp;
    }

    //Functions to set boolean so we dont use event functions
    public void SetABool()
    {
        StartSystemManager._Current.Abutton();
    }
    public void SetBBool()
    {
        StartSystemManager._Current.Bbutton();
    }
    public void SetCBool()
    {
        StartSystemManager._Current.Cbutton();
    }
    public void SetDBool()
    {
        StartSystemManager._Current.Dbutton();
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
