using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_reset_transform : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
