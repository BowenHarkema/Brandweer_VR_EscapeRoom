using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlinkeyTextScript : MonoBehaviour
{
    public float timer;
    public TextMeshProUGUI TextMeshProUGUI;

    // Update is called once per frame
    void Update()
    {
        //Blinks the selected text on screen each second
        timer = timer >= 1 ? 0 : timer + Time.deltaTime;
        TextMeshProUGUI.enabled = timer >= 1 ? false : timer >= 0.5 ? true : false;
    }
}
