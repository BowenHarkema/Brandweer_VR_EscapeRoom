using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Valve_display : MonoBehaviour
{
    public Slider nutrient_display;
    public TextMeshProUGUI percentageNumber;
    private float _ButtonCooldown = 0.5f;

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
