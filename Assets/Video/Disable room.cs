using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disableroom : MonoBehaviour
{
    [SerializeField] private GameObject _ToDisable;

    private void OnTriggerExit(Collider other)
    {
       if(other.CompareTag("RenderCam"))
        {
            _ToDisable.SetActive(false);
        }
    }
}
