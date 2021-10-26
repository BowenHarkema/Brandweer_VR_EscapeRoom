﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Plant_pod_script : MonoBehaviour
{
    //  plant pod plant selection ENUM
    public enum Selected_plant
    {
        Arctium_lappa = 0
            , Pteropsida = 1
            , Ignis_Herba = 2
            , Corona_Flos = 3
            , Taraxacum = 4
            , Pluma = 5
            , Brassica_oleracea = 6
            , harambe_plumbus = 7
            , Zizania = 8
            , Vrouwentong = 9
            , Heracleum_sphondylium = 10
            , Kopstekel_Flora = 11
    }
    public Selected_plant plant_selection = Selected_plant.Arctium_lappa;
    public List<GameObject> plant_prefabs;
    public Material Alive_texture;
    public Material Dead_texture;
    public string plantName;

    public int target_oxygen;
    public int target_water;
    public int target_temperature;

    public Slider oxygen_current;
    public Slider water_current;
    public Slider temperature_current;

    public bool oxygen;
    public bool water;
    public bool temperature;

    public bool Nutrients_balanced;

    public int broken_pod_chance;

    public GameObject plant_placeholder;
    public GameObject fire_placeholder;
    public GameObject barcode;
    private GameObject newplant;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        //Checks if nutrient values match their target
        oxygen = oxygen_current.value == target_oxygen ? true : false;
        water = water_current.value == target_water ? true : false;
        temperature = temperature_current.value == target_temperature ? true : false;

        //check if plant is balanced
        Nutrients_balanced = temperature && water && oxygen ? true : false;

        //sets alive or dead texture if the nutrients are balanced
        plant_placeholder.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = Nutrients_balanced == true ? Alive_texture : Dead_texture;

    }
//Handles the first spawning of the plant, aswell as chance calculation if its broken
    public void spawnPlant() 
    {
      //  GameObject.Destroy(plant_placeholder.transform.GetChild(0).gameObject);
        GameObject newplant = Instantiate(plant_prefabs[Random.Range(0, plant_prefabs.Count)], plant_placeholder.transform);
        newplant.transform.localPosition = new Vector3(0, 0, 0);
        newplant.transform.parent = plant_placeholder.transform;

        barcode.GetComponent<Barcode>().Code_value = plantName;

        int chance = Random.Range(0, 100);
        if (broken_pod_chance > chance)
        {
            oxygen_current.value = Mathf.Floor(Random.Range(0, 100) / 10) * 10;
            water_current.value = Mathf.Floor(Random.Range(0, 100) / 10) * 10;
            temperature_current.value = Mathf.Floor(Random.Range(0, 100) / 10) * 10;
            newplant.GetComponent<MeshRenderer>().material = Dead_texture;
            

            if (Random.Range(0, 100) < 25)
            {
                fire_placeholder.SetActive(true);
            }

        }
        else
        {
            oxygen_current.value = target_oxygen;
            water_current.value = target_water;
            temperature_current.value = target_temperature;
            fire_placeholder.SetActive(false);
        }

    }
}
