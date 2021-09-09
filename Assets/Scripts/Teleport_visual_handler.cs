using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class Teleport_visual_handler : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private XRController controller;
    public MonoBehaviour LineRendererScript;
    
   
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        controller = gameObject.GetComponent<XRController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch,out bool touched))
        {
            if(touched == true) { 
            lineRenderer.enabled = true;
            LineRendererScript.enabled = true;

        }
            else
        {
            lineRenderer.enabled = false;
            LineRendererScript.enabled = false;
        }

        }
    }
}
