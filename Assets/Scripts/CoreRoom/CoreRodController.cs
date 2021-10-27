using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using System;

public class CoreRodController : MonoBehaviour
{
    public UnityEvent onPressed, onReleased;

    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f;

    [SerializeField] public RodHandler rodNameSend;
    [SerializeField] public string rodNumber;

    [SerializeField] public bool isPressed;
    [SerializeField] public bool P_wrongSequence;


    [SerializeField] private Vector3 _startPos;
    [SerializeField] private Vector3 originalPos;
    [SerializeField] private ConfigurableJoint _joint;
    [SerializeField] private GameObject _rod;
    [SerializeField] private Rigidbody _rb;

    //zet start positie en save start positie in originalpos. Joint is de config joint op de cirkle om de rod heen.
    void Start()
    {

        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();

    }

    void Update()
    {
        
        if (!isPressed && GetValue() + threshold >= 1)
        {
       
            Pressed();
           
        }
       
    }

    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
            value = 0;

        return Mathf.Clamp(value, -1f, 1f);

    }
    //Stuur de rod naam door naar de hanlder zet
    //zet de publieke bool naar pressed
    //invoke laad de CoreRoomHandler
    private void Pressed()
    {
        rodNameSend.rodNameSetter = rodNumber;
        isPressed = true;
        _rb.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation; 
        onPressed.Invoke();
        print("pressed rod");
    }

    public void ResetPosition()
    {
        transform.position = originalPos;
        _rb.constraints =
           RigidbodyConstraints.FreezeRotationX |
           RigidbodyConstraints.FreezeRotationZ |
           RigidbodyConstraints.FreezeRotationY |
           RigidbodyConstraints.FreezePositionX |
           RigidbodyConstraints.FreezePositionZ;
    }

}
