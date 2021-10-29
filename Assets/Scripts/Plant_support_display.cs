using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plant_support_display : MonoBehaviour
{
    public TextMeshProUGUI goodpods;
    public TextMeshProUGUI badpods;
    public Plant_pods_controller plant_Pods_Controller;

    // Update is called once per frame
    void Update()
    {
        //displays the amount of working and broken plantpods 
        int brokenpods = plant_Pods_Controller.getBrokenPods();

        goodpods.text = "";
        badpods.text = "";        

        for (int i = 0; i < 6 - brokenpods + 1; i++)
        {
            goodpods.text += "█ ";
        }

        for (int i = 0; i < brokenpods + 1; i++)
        {
            badpods.text += "█ ";
        }
    }
}
