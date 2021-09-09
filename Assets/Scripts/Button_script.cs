using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Button_script : MonoBehaviour
{

    public float TargetValue;
    public UnityEvent onTrigger;
    private float ButtonCooldown = 3.0f;

    private bool Triggered;
    // Start is called before the first frame update
    void Start()
    {
        Triggered = false;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.transform.localPosition.y <= TargetValue && !Triggered)
        {
            Debug.Log("triggerd");
            onTrigger.Invoke();
            Triggered = true;
        }

        if (Triggered)
        {
            ButtonCooldown -= Time.deltaTime;
            if(ButtonCooldown < 0)
            {
                Triggered = false;
                ButtonCooldown = 3.0f;
            }
        }
    }
}