﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovementScript : MonoBehaviour
{
    public float speed = 1.5f;
   [SerializeField] public bool moveF = false;
   [SerializeField] public bool moveB = false;
   [SerializeField] public bool rotateL = false;
   [SerializeField] public bool rotateR = false;

    private void Update()
    {
        if (moveB)
            transform.Translate(0, 0, -speed * Time.deltaTime);
        if (moveF)
            transform.Translate(0, 0, speed * Time.deltaTime);
        if (rotateL)
            transform.Rotate(0, -20f * Time.deltaTime , 0);
        if (rotateR)
            transform.Rotate(0, 20f * Time.deltaTime, 0);
    }

    public void boolSetF(bool b)
    {
        moveB = b;
    }

    public void boolSetB(bool b)
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