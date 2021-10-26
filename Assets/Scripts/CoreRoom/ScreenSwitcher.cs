using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitcher : MonoBehaviour
{
    [SerializeField] ChangeCamera changeCamera;

    [SerializeField] public GameObject _Canvas;
    [SerializeField] private RenderTexture _Camera1;
    [SerializeField] private RenderTexture _Camera2;
    [SerializeField] public bool cam1;
    [SerializeField] public bool cam2;

    // Start is called before the first frame update
    public void ChangeCamOne()
    {
        
        _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera2;
        
        
    }

    public void ChangeCamTwo()
    {
        
        _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera1;
       

    }

    // Update is called once per frame
    void Update()
    {
        if(cam1 == true)
        {
            ChangeCamOne();
        
        }
        if(cam2 == true)
        {
            ChangeCamTwo();

        }
      
    }
}
