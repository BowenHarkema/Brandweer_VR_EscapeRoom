using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class Teleport_visual_handler : MonoBehaviour
{
    private LineRenderer _LineRenderer;
    private XRController _Controller;
    public MonoBehaviour LineRendererScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _LineRenderer = gameObject.GetComponent<LineRenderer>();
        _Controller = gameObject.GetComponent<XRController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_Controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisTouch,out bool touched))
        {
            _LineRenderer.enabled = touched == true ? true : false;
            LineRendererScript.enabled = touched == true ? true : false;
        }
    }
}
