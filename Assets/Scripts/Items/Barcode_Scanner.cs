using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barcode_Scanner : MonoBehaviour
{
    public TextMeshProUGUI Code_text;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "barcode")
            Code_text.text = collision.gameObject.GetComponent<Barcode>().Code_value;
    }
}
