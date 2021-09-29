using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    // 
    [SerializeField]
    private bool isFront;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Shelf")
        {
            if (isFront)
            {
                print("er is contact voor");
            }
            else
            {
                print("er is contact achter");
            }
            //freeze button front
            
        }
        else
        {
            print("je kan gassen maat");
        }
    }
}
