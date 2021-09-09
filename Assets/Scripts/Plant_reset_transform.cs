using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_reset_transform : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
