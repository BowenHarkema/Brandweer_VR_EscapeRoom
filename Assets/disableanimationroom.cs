using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disableanimationroom : MonoBehaviour
{
    [SerializeField] private GameObject _ToDisable;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("RenderCam"))
        {
            Debug.Log("WTF");
            _ToDisable.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RenderCam"))
        {
            Debug.Log("WTF2");
            _ToDisable.active = false;
        }
    }
}
