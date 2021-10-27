using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    [SerializeField]
    public UnityEvent _OnPressed, _OnReleased;

    [SerializeField]
    private float _Threshold = .1f;

    [SerializeField]
    private float _DeadZone = .025f;

    [SerializeField]
    private bool _IsPressed = false;

    [SerializeField]
    private bool _IsOneTimeButton = false;

    private Vector3 StartPos;
    private ConfigurableJoint Joint;
    private bool _IsAlreadyPressed = false;
    private Rigidbody _RigidBody;

    //Set refs
    void Start()
    {
        StartPos = transform.localPosition;
        Joint = GetComponent<ConfigurableJoint>();
        _RigidBody = gameObject.GetComponent<Rigidbody>();
    }

    //Check if button is pressed
    void Update()
    {
        if (!_IsPressed && GetValue() + _Threshold >= 1)
        {
            Pressed();
        }
        if (_IsPressed && GetValue() - _Threshold <= 0)
        {
            Released();
        }
    }

    //Function to get bck 0 or 1
    private float GetValue()
    {
        var value = Vector3.Distance(StartPos, transform.localPosition) / Joint.linearLimit.limit;

        if (Mathf.Abs(value) < _DeadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    //Pressed function
    private void Pressed()
    {
        if (_IsOneTimeButton)
        {
            if (!_IsAlreadyPressed)
            {
                _IsPressed = true;
                _OnPressed.Invoke();
                _IsAlreadyPressed = true;
            }
        }
        else
        {
            _IsPressed = true;
            _OnPressed.Invoke();
        }
    }

    //Released function
    private void Released()
    {
        _IsPressed = false;
        _IsAlreadyPressed = false;
        _OnReleased.Invoke();
    }
}
