using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Plant_pod_script : MonoBehaviourPunCallbacks
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
    public int podNumber;

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
    public bool plantIsBroken;

    public GameObject plant_placeholder;
    public GameObject fire_placeholder;
    public GameObject barcode;

    [SerializeField] private ExitGames.Client.Photon.Hashtable _PodProps = new ExitGames.Client.Photon.Hashtable();

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

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable property)
    {
        if (property.ContainsKey("Oxygen" + podNumber.ToString()))
        {
            oxygen_current.value = (float)PhotonNetwork.CurrentRoom.CustomProperties["Oxygen" + podNumber.ToString()];
            Debug.Log("property changed: " + oxygen_current.value);
        }
        if (property.ContainsKey("Water" + podNumber.ToString()))
        {
            oxygen_current.value = (float)PhotonNetwork.CurrentRoom.CustomProperties["Water" + podNumber.ToString()];
            Debug.Log("property changed: " + oxygen_current.value);
        }
        if (property.ContainsKey("Temp" + podNumber.ToString()))
        {
            oxygen_current.value = (float)PhotonNetwork.CurrentRoom.CustomProperties["Temp" + podNumber.ToString()];
            Debug.Log("property changed: " + oxygen_current.value);
        }
    }

    //Handles the first spawning of the plant, as well as set values for plants so its values are the same to every player
    public void spawnPlant() 
    {
        GameObject newplant = Instantiate(plant_prefabs[Random.Range(0, plant_prefabs.Count)], plant_placeholder.transform);
        newplant.transform.localPosition = new Vector3(0, 0, 0);
        newplant.transform.parent = plant_placeholder.transform;

        barcode.GetComponent<Barcode>().Code_value = plantName;

        //checks if plant is broken (bool is set in unity) then sets its nutrients values
        if (plantIsBroken)
        {
            newplant.GetComponent<MeshRenderer>().material = Dead_texture;
            switch (podNumber)
            {
                case 1:
                    oxygen_current.value = 10;
                    water_current.value = 70;
                    temperature_current.value = 50;
                    fire_placeholder.SetActive(false);
                    break;
                case 2:
                    oxygen_current.value = 10;
                    water_current.value = 20;
                    temperature_current.value = 20;
                    fire_placeholder.SetActive(true);
                    break;
                case 3:
                    oxygen_current.value = 80;
                    water_current.value = 30;
                    temperature_current.value = 0;
                    fire_placeholder.SetActive(false);
                    break;
                case 4:
                    oxygen_current.value = 10;
                    water_current.value = 30;
                    temperature_current.value = 50;
                    fire_placeholder.SetActive(true);
                    break;
                case 5:
                    oxygen_current.value = 100;
                    water_current.value = 30;
                    temperature_current.value = 10;
                    fire_placeholder.SetActive(false);
                    break;
                case 6:
                    oxygen_current.value = 60;
                    water_current.value = 70;
                    temperature_current.value = 50;
                    fire_placeholder.SetActive(true);
                    break;
            }
        }
        else
        {
            oxygen_current.value = target_oxygen;
            water_current.value = target_water;
            temperature_current.value = target_temperature;
            fire_placeholder.SetActive(false);
        }

        _PodProps["Oxygen" + podNumber.ToString()] = oxygen_current.value;
        _PodProps["Water" + podNumber.ToString()] = water_current.value;
        _PodProps["Temp" + podNumber.ToString()] = temperature_current.value;

        PhotonNetwork.CurrentRoom.SetCustomProperties(_PodProps);
    }
}
