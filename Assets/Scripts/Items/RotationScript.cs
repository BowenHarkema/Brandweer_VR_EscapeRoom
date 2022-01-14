using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{
    private bool rotate;
    // Start is called before the first frame update
    void Start()
    {
        rotate = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            transform.Rotate(Vector3.up * Time.deltaTime);
        }
    }
}
