using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    [SerializeField] private bool _isButtonPressed;
    public bool P_isButtonPressed { get { return _isButtonPressed; } set { _isButtonPressed = value; } }


    // Start is called before the first frame update
    void Start()
    {
        P_isButtonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
