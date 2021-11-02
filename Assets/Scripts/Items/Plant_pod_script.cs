using System.Collections;
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

    [Range(1.0f, 0.0f)]
    public float target_oxygen;
    [Range(1.0f, 0.0f)]
    public float target_water;
    [Range(1.0f, 0.0f)]
    public float target_nutrient;

    public Slider oxygen_current;
    public Slider water_current;
    public Slider nutrient_current;

    public bool oxygen;
    public bool water;
    public bool nutrient;

    public bool onfire;

    public bool Nutrients_balanced;

    [Range(0, 100)]
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

        /*Nutrient balance checking
         * this part of code checks if the nutrients are correctly balanced
         */
        //oxygen
        if ((oxygen_current.value) > (target_oxygen - 0.05))
        {
            if ((oxygen_current.value) < (target_oxygen + 0.05))
            {
                oxygen = true;
            }
            else
            {
                oxygen = false;
            }
        }
        else
        {
            oxygen = false;
        }
        //water
        if ((water_current.value) > (target_water - 0.05))
        {
            if ((water_current.value) < (target_water + 0.05))
            {
                water = true;
            }
            else
            {
                water = false;
            }
        }
        else
        {
            water = false;
        }
        //nutrients

        if ((nutrient_current.value) > (target_nutrient - 0.05))
        {
            if ((nutrient_current.value) < (target_nutrient + 0.05))
            {
                nutrient = true;
            }
            else
            {
                nutrient = false;
            }
        }
        else
        {
            nutrient = false;
        }

        if (nutrient && water && oxygen)
        {
            Nutrients_balanced = true;
            plant_placeholder.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = Alive_texture;
        }
        else
        {
            Nutrients_balanced = false;
            plant_placeholder.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material = Dead_texture;
        }

        if (onfire)
        {
            fire_placeholder.SetActive(true);
        }
        else
        {
            fire_placeholder.SetActive(false);
        }

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
            oxygen_current.value = Random.Range(0.0f, 1.0f);
            water_current.value = Random.Range(0.0f, 1.0f);
            nutrient_current.value = Random.Range(0.0f, 1.0f);
            newplant.GetComponent<MeshRenderer>().material = Dead_texture;


            if (Random.Range(0, 100) < 25)
            {
                onfire = true;
            }

        }
        else
        {
            oxygen_current.value = target_oxygen;
            water_current.value = target_water;
            nutrient_current.value = target_nutrient;
        }

    }
}
