using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Plant_pods_controller : MonoBehaviour
{
    public PlantsDB Plant_DB;
    private Plant_pod_script[] podscripts;
    [SerializeField] private ProgressManager _ProgressManager;
    void Start()
    {
        podscripts = gameObject.GetComponentsInChildren<Plant_pod_script>();
        PopulatePlantPods();
    }

    //Handles plant population from plant Database
    public void PopulatePlantPods()
    {
        foreach (Plant_pod_script pod_Script in podscripts)
        {
            int selectionNumber = (int)pod_Script.plant_selection;
            pod_Script.plant_prefabs = Plant_DB.PlantPorperties[selectionNumber].plant_prefabs;
            pod_Script.Alive_texture = Plant_DB.PlantPorperties[selectionNumber].Alive_texture;
            pod_Script.Dead_texture = Plant_DB.PlantPorperties[selectionNumber].Dead_texture;
            pod_Script.plantName = Plant_DB.PlantPorperties[selectionNumber].dropDown.ToString().Replace("_", " ");
            pod_Script.target_oxygen = Plant_DB.PlantPorperties[selectionNumber].oxygen;
            pod_Script.target_water = Plant_DB.PlantPorperties[selectionNumber].water;
            pod_Script.target_temperature = Plant_DB.PlantPorperties[selectionNumber].temperature;
            pod_Script.spawnPlant();
        }
    }

    //gets the amount of broken plant pods by checking if nutrients are balanced
    public int getBrokenPods()
    {
        int pods = 0;
        foreach(Plant_pod_script pod_Script in podscripts)
        {
            if(pod_Script.Nutrients_balanced == false)
            {
                pods++;
            }
        }

        Debug.Log(pods);

        if(pods <= 0)
        {
            _ProgressManager.RoomFixed(2);
        }

        return pods;
    }
}

