using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.Events;

public class StartSystemManager : MonoBehaviour
{
    public static StartSystemManager _Current;

    [SerializeField]
    private List<int> _Sequence_Order;

    [SerializeField]
    private List<int> _Current_Sequence_Order;
    public List<int> P_Current_sequence_Order { get { return _Current_Sequence_Order; } }

    public UnityEvent _FixedEvent = new UnityEvent();

    //Set the manager as singleton item.
    private void Awake()
    {
        _Current = this;
    }

    //Fixed update to check data and fix items.
    private void FixedUpdate()
    {
        if(_Current_Sequence_Order.Count() > _Sequence_Order.Count())
        {
            _Current_Sequence_Order = new List<int>();
        }

        if(_Current_Sequence_Order.Count() == _Sequence_Order.Count())
        {
            if (_Current_Sequence_Order.SequenceEqual(_Sequence_Order))
            {
                Debug.Log("Engine started");
                _FixedEvent.Invoke();
            }
            else
            {
                Debug.Log("Try again");
                _Current_Sequence_Order = new List<int>();
            }
        }
    }

    //event and function for manager.
    public event Action OnAbutton;
    public void Abutton()
    {
        if (OnAbutton != null)
        {
            OnAbutton();
            _Current_Sequence_Order.Add(1);
        }
    }

    //event and function for manager.
    public event Action OnBbutton;
    public void Bbutton()
    {
        if (OnBbutton != null)
        {
            OnBbutton();
            _Current_Sequence_Order.Add(2);
        }
    }

    //event and function for manager.
    public event Action OnCbutton;
    public void Cbutton()
    {
        if (OnBbutton != null)
        {
            OnDbutton();
            _Current_Sequence_Order.Add(3);
        }
    }

    //event and function for manager.
    public event Action OnDbutton;
    public void Dbutton()
    {
        if (OnBbutton != null)
        {
            OnDbutton();
            _Current_Sequence_Order.Add(4);
        }
    }
}
