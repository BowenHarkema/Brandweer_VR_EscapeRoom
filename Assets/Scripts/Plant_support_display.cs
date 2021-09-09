using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Plant_support_display : MonoBehaviour
{
    public TextMeshProUGUI goodpods;
    public TextMeshProUGUI badpods;
    public Plant_pods_controller plant_Pods_Controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        int workingpods = plant_Pods_Controller.getWorkingPods();
        int brokenpods = plant_Pods_Controller.getBrokenPods();

        string goodpodstext = "";
        string badpodstext = "";
        
        

        for (int i = 0; i < workingpods + 1; i++)
        {
            goodpodstext += "█ ";

        }
        for (int i = 0; i < brokenpods + 1; i++)
        {
            badpodstext += "█ ";
        }

        goodpods.text = goodpodstext;
        badpods.text = badpodstext;
    }
}
