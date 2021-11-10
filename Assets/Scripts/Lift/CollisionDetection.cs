using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    /// <summary>
    /// OnTrigger check if the box collider from the scissor_lift touches any objects with the tag "Wall" or "Shelf"
    /// If contact with said tagged object persists disallow movement in the respective destination
    /// </summary>

    [SerializeField]
    private bool _IsFront;
    /// makes sure the box collider is the back box collider
    [SerializeField]
    private bool _IsBack;
    /// <summary>
    /// Allows the call to the ControllerMovementScript that passes the public bool for car movement
    /// and dissalows if contact persists
    /// </summary>
    [SerializeField] private ControllerMovementScript _controllerMovementScript;


    private void OnTriggerEnter(Collider collider)
    {
        //checks if collision of the collider is with a shelf or wall on enter, then checks for the front or back side of the cart
        if (collider.gameObject.tag == "Shelf" || collider.gameObject.tag == "Wall")
        {
            if (_IsFront)
            {
                _controllerMovementScript.P_isLockedForward = true;
                _controllerMovementScript.P_isLockedBack = false;
            }
            if (_IsBack)
            {
                _controllerMovementScript.P_isLockedBack = true;
                _controllerMovementScript.P_isLockedForward = false;
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        //checks if collision of the collider is with a shelf or wall on exit, then checks for the front or back side of the cart
        if (collider.gameObject.tag == "Shelf" || collider.gameObject.tag == "Wall")
        {
            if (_IsFront)
            {
                _controllerMovementScript.P_isLockedForward = false;
            }
            if (_IsBack)
            {
                _controllerMovementScript.P_isLockedBack = false;
            }
        }
    }
}