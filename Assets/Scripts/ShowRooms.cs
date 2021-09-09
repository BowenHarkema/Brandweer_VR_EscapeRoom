using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowRooms : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject connectedRoom1;
    public GameObject connectedRoom2;

    public void showRoom()
    {
        connectedRoom1.SetActive(true);
        connectedRoom2.SetActive(true);
    }
    public void HideRoom()
    {
        connectedRoom1.SetActive(false);
        connectedRoom2.SetActive(false);
    }
}
