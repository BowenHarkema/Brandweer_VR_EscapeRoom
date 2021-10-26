using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Valve_display : MonoBehaviour
{
    public Slider nutrient_display;
    //public GameObject valve;
    public TextMeshProUGUI percentageNumber;
    //public float offset_val;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        percentageNumber.text = nutrient_display.value.ToString();
    }
    public void add()
    {
        int _percentageNumber = int.Parse(percentageNumber.text);
        nutrient_display.GetComponent<Slider>().value = _percentageNumber != 100 ? (_percentageNumber + 10) : _percentageNumber;
    }
    public void subtract()
    {
        int _percentageNumber = int.Parse(percentageNumber.text);
        nutrient_display.GetComponent<Slider>().value = _percentageNumber != 0 ? (_percentageNumber - 10) : _percentageNumber;
    }
}
