using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Barcode_Scanner : MonoBehaviour
{
    public TextMeshProUGUI Code_text;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision" + collision.gameObject.tag);
        if (collision.gameObject.tag == "barcode")
        {
            Debug.Log("barcode collision");
            Code_text.text = collision.gameObject.GetComponent<Barcode>().Code_value;
        }
    }

}
