using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever_script : MonoBehaviour
{
    public float TargetValue;
    public UnityEvent onTrigger;

    private bool Triggered;
    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
      
        if (gameObject.transform.rotation.x <= TargetValue && !Triggered)
        {
            onTrigger.Invoke();
            Triggered = true;
        }
    }
}
