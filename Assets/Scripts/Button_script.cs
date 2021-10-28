using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Button_script : MonoBehaviour
{

    public float TargetValue;
    public UnityEvent onTrigger;

    private bool _Triggered = false;

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.transform.localPosition.y <= TargetValue && !_Triggered)
        {
            onTrigger.Invoke();
            _Triggered = true;
        }
        _Triggered = false;
    }
}