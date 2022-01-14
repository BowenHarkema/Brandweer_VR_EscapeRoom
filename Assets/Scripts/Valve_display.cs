using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;
using Photon.Pun;

public class Valve_display : MonoBehaviour
{
    public Slider nutrient_display;
    public TextMeshProUGUI percentageNumber;

    [SerializeField] private string _Typestring;
    [SerializeField] private Plant_pod_script _PlantPod;
    [SerializeField] private ExitGames.Client.Photon.Hashtable _PodProps = new ExitGames.Client.Photon.Hashtable();

    // Update is called once per frame
    void Update()
    {
        percentageNumber.text = nutrient_display.value.ToString();
    }

    //changes the slider value, parameters are given in add() and substract() , where plus is true and minus is false
    private void changeSlider(int limitNumber, bool plusOrMinus)
    {
        int _percentageNumber = int.Parse(percentageNumber.text);
        if (plusOrMinus)
            nutrient_display.GetComponent<Slider>().value = _percentageNumber != limitNumber ? (_percentageNumber + 10) : _percentageNumber;
        else
            nutrient_display.GetComponent<Slider>().value = _percentageNumber != limitNumber ? (_percentageNumber - 10) : _percentageNumber;

        _PodProps[_Typestring + _PlantPod.podNumber.ToString()] = nutrient_display.GetComponent<Slider>().value;
        PhotonNetwork.CurrentRoom.SetCustomProperties(_PodProps);
    }

    //These call the change slider function with the first parameter being its max value and bool to check to go up or down
    public void add()
    {
        changeSlider(100, true);
    }

    public void subtract()
    {
        changeSlider(0, false);
    }
}
