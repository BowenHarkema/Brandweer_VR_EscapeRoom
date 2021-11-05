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
    private bool isFront;
    /// makes sure the box collider is the back box collider
    [SerializeField]
    private bool isBack;
    /// <summary>
    /// Allows the call to the ControllerMovementScript that passes the public bool for car movement
    /// and dissalows if contact persists
    /// </summary>
    [SerializeField] private ControllerMovementScript _controllerMovementScript;


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Shelf" || collider.gameObject.tag == "Wall")
        {
            if (isFront)
            {
                print("er is contact voor stopt");
                _controllerMovementScript.P_isLockedForward = true;
                _controllerMovementScript.P_isLockedBack = false;

            }
            if (isBack)
            {
                _controllerMovementScript.P_isLockedBack = true;
                _controllerMovementScript.P_isLockedForward = false;
                print("er is contact achter stopt");
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

                print("er is geen contact voor ");
            }
            if (isBack)
            {
                _controllerMovementScript.P_isLockedBack = false;
                print("er is geen contact achter");
            }


        }
    }
}