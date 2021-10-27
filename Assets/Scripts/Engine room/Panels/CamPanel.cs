using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPanel : MonoBehaviour
{
    [SerializeField] public GameObject _Canvas;
    [SerializeField] private RenderTexture _Camera1;
    [SerializeField] private RenderTexture _Camera2;
    [SerializeField] public bool Cam;

    // Start is called before the first frame update
    public void ChangeCam()
    {
        Cam = !Cam;

        if(Cam)
        {
            _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera2;
        }
        else
        {
            _Canvas.GetComponent<Renderer>().material.mainTexture = _Camera1;
        }
    }
}
