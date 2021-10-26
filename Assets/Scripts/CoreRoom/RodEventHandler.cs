using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RodEventHandler : MonoBehaviour
{
    [SerializeField]
    public UnityEvent OnPressed, OnReleased;

    [SerializeField]
    private float Threshold = .1f;

    [SerializeField]
    private float DeadZone = .025f;

    [SerializeField]
    private bool IsPressed = false;

    [SerializeField]
    private Vector3 StartPos;

    [SerializeField]
    private ConfigurableJoint Joint;

    void Start()
    {
        StartPos = transform.localPosition;
        Joint = GetComponent<ConfigurableJoint>();
    }

    void Update()
    {
        if (!IsPressed && GetValue() + Threshold >= 1)
        {
            Pressed();
        }
        if (IsPressed && GetValue() - Threshold <= 0)
        {
            Released();
        }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(StartPos, transform.localPosition) / Joint.linearLimit.limit;

        if (Mathf.Abs(value) < DeadZone)
        {
            value = 0;
        }

        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        IsPressed = true;
        OnPressed.Invoke();
    }

    private void Released()
    {
        IsPressed = false;
        OnReleased.Invoke();
    }
}