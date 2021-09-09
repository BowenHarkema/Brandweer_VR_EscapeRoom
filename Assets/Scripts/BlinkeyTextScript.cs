using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkeyTextScript : MonoBehaviour
{
    private bool Blinking;
    public float timer;
    public TextMeshProUGUI TextMeshProUGUI;
    
    // Start is called before the first frame update
    void Start()
    {
        Blinking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Blinking == true)
        {
            timer = timer + Time.deltaTime;
            if(timer >= 0.5)
            {
                TextMeshProUGUI.enabled = true;
            }
            if(timer >= 1)
            {
                TextMeshProUGUI.enabled = false;
                timer = 0;
            }
        }
    }
}
