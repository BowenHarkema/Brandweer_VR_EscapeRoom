// ----------------------------------------------------------------------------------------------------------
// Door script copyright 2017 by Creepy Cat do not distribute/sale full or partial code without my permission
// ----------------------------------------------------------------------------------------------------------
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class DoorDoubleSlide2 : MonoBehaviour {
    
    //Doors
    public Transform doorL = null;
    public Transform doorR = null;

    private Vector3 initialDoorL;
    private Vector3 initialDoorR;
    private Vector3 doorDirection;

    public enum Direction { X, Y, Z };
    public Direction directionType = Direction.Y;

    //Control Variables
    public float speed = 2.0f;
    public float openDistance = 2.0f;

    //Internal... stuff
    private float _Point = 0.0f;
    private bool _Opening = false;

   

    //Record initial door positions
	void Start () {
        if (doorL)
            initialDoorL = doorL.localPosition;

        if (doorR)
            initialDoorR = doorR.localPosition;  
	}

    //Something approaching? open doors
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
           gameObject.GetComponent<ShowRooms>().showRoom();
            _Opening = true;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        }

    }

    //Something left? close doors
    async void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _Opening = false;

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            //3 second delay before room is hidden, gives the door time to fully close
            await Task.Delay(3000);
            gameObject.GetComponent<ShowRooms>().HideRoom();
        }
    }

    //force opens a door, for instance the reactor doors when all generators are up
    public void forceOpenDoors()
    {
        _Opening = true;
    }

    //Open or close doors
	void Update () {
        // Direction selection
        doorDirection = directionType == Direction.X ? Vector3.right : directionType == Direction.Y ? Vector3.up : Vector3.back;

        // If _Opening
        _Point = _Opening ? Mathf.Lerp(_Point, 1.0f, Time.deltaTime * speed) : Mathf.Lerp(_Point, 0.0f, Time.deltaTime * speed);

        // Move doors
        if (doorL)
            doorL.localPosition = initialDoorL + (doorDirection * _Point * openDistance);

        if (doorR)
            doorR.localPosition = initialDoorR + (-doorDirection * _Point * openDistance);
	}
}
