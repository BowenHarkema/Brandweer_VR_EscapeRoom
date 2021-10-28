using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovementScript : MonoBehaviour
{
   [SerializeField] private bool _isLockedForward;
    public bool P_isLockedForward { get { return _isLockedForward; } set { _isLockedForward = value; } }
    [SerializeField] private bool _isLockedBack;
    public bool P_isLockedBack { get { return _isLockedBack; } set { _isLockedBack = value; } }
    public float speed = 1.5f;
   [SerializeField] public bool moveF = false;
   [SerializeField] public bool moveB = false;
   [SerializeField] public bool rotateL = false;
   [SerializeField] public bool rotateR = false;

    private void Update()
    {
        //checks if one of the sides of the cart is collided and moves cart if it isnt
        if (_isLockedBack)
        {
            moveB = false;
        }
        if (_isLockedForward)
        {
            moveF = false;
        }
        if (moveB)
            transform.Translate(0, 0, speed * Time.deltaTime);
        if (moveF)
            transform.Translate(0, 0, -speed * Time.deltaTime);
        if (rotateL)
            transform.Rotate(0, -20f * Time.deltaTime , 0);
        if (rotateR)
            transform.Rotate(0, 20f * Time.deltaTime, 0);
    }

    //Functions called from unity events on the storage buttons, when pressed sets boolean to true and moves the cart in pressed direction
    public void boolSetB(bool b)
    { 
        moveB = b;
    }
    public void boolSetF(bool b)
    {
        moveF = b;
    }
    public void boolSetRotateL(bool b)
    {
        rotateL = b;
    }
    public void boolSetRotateR(bool b)
    {
        rotateR = b;
    }
}
