using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // 

    [SerializeField]
    private bool isFront;
    [SerializeField]
    private bool isBack;
    [SerializeField] private ControllerMovementScript _controllerMovementScript;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Shelf" || collider.gameObject.tag == "Wall")
        {
            if (isFront)
            {
                _controllerMovementScript.P_isLockedForward = true;
                print("er is contact voor true");
            }
            if (isBack)
            {
                _controllerMovementScript.P_isLockedBack = true;
                print("er is contact achter true");
            }
            

        }
       
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Shelf" || collider.gameObject.tag == "Wall")
        {
            if (isFront)
            {
                _controllerMovementScript.P_isLockedForward = false;
                print("er is contact voor false");
            }
            if (isBack)
            {
                _controllerMovementScript.P_isLockedBack = false;
                print("er is contact achter false");
            }
            

        }
    }
}
