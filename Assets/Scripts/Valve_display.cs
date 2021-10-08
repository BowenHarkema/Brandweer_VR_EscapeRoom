using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Valve_display : MonoBehaviour
{
    public Slider nutrient_display;
    public GameObject valve;
    public TextMeshProUGUI precentageNumber;
    public float offset_val;
    [SerializeField]
    private bool _isTurnedMinus = false;
    [SerializeField]
    private bool _isTurnedPlus = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        precentageNumber.text = System.Math.Round((10 * nutrient_display.value)).ToString();
        if (valve.transform.rotation.eulerAngles.z > 10 && valve.transform.rotation.eulerAngles.z < 180)
        {

            _isTurnedMinus = true;
            _isTurnedPlus = false;
            if (_isTurnedMinus == true)
            {
                Wait();
                nutrient_display.GetComponent<Slider>().value = nutrient_display.GetComponent<Slider>().value - offset_val * Time.deltaTime;
                
                //-= 10 * Time.deltaTime;


            }
            //nutrient_display.GetComponent<Slider>().value = -offset_val; 
        }
        if (valve.transform.rotation.eulerAngles.z < 350 && valve.transform.rotation.eulerAngles.z > 180)
        {
            _isTurnedPlus = true;
            _isTurnedMinus = false;
            if (_isTurnedPlus == true)
            {
                Wait();
                nutrient_display.GetComponent<Slider>().value = nutrient_display.GetComponent<Slider>().value + offset_val * Time.deltaTime;
                
                //+= 10 * Time.deltaTime;
            }
            //nutrient_display.GetComponent<Slider>().value = +offset_val;
        }

    }
    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
    }
    /* public void add()
     {
         nutrient_display.GetComponent<Slider>().value = nutrient_display.GetComponent<Slider>().value + offset_val;
     }
     public void subtract()
     {
         nutrient_display.GetComponent<Slider>().value = nutrient_display.GetComponent<Slider>().value - offset_val;
     }*/
}
