using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    /// <summary>
    /// OnTrigger check if the box collider from the scissor_lift touches any objects with the tag "Wall" or "Shelf"
    /// If contact with said tagged object persists disallow movement in the respective destination
    /// </summary>

    /// makes sure the box collider is the front box collider
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
