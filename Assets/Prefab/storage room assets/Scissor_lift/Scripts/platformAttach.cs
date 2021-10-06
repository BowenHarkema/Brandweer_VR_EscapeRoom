using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformAttach : MonoBehaviour
{

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.transform.parent = transform;
            //other.transform.parent = transform;
            print("ben ik er op");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.parent.transform.parent = null;
            //other.transform.parent = null;
            print("ben ik er van af");
        }
    }
    //public void onActivate()
    //{
    //    if (gameObject.tag == "Player")
    //    {
    //        vrPlayer.transform.parent = transform;
    //        print("ben ik er op");
    //    }
    //}

    //public void onDeactivate()
    //{
    //    if (gameObject.tag == "Player")
    //    {
    //        vrPlayer.transform.parent = null;
    //        print("ben ik er van af");
    //    }
    //}


}
