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

    private Vector3 _InitialDoorL;
    private Vector3 _InitialDoorR;
    private Vector3 _DoorDirection;

    //DirectionType needs to be set in unity
    public enum Direction { X, Y, Z };
    public Direction directionType;

    //Control Variables
    public float speed = 2.0f;
    public float openDistance = 2.0f;

    //Internal... stuff
    private float _Point = 0.0f;
    private bool _Opening = false;


    //Record initial door positions
	void Start () {
        if (doorL)
            _InitialDoorL = doorL.localPosition;

        if (doorR)
            _InitialDoorR = doorR.localPosition;  
	}

    //Something approaching? open doors if collider is a player
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
           gameObject.GetComponent<ShowRooms>().showRoom();
            _Opening = true;

        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        }

    }

    //Something left? close doors if collider is a player
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
        // Direction selection in which the door will open
        _DoorDirection = directionType == Direction.X ? Vector3.right : directionType == Direction.Y ? Vector3.up : Vector3.back;

        // If _Opening
        _Point = _Opening ? Mathf.Lerp(_Point, 1.0f, Time.deltaTime * speed) : Mathf.Lerp(_Point, 0.0f, Time.deltaTime * speed);

        // Move doors
        if (doorL)
            doorL.localPosition = _InitialDoorL + (_DoorDirection * _Point * openDistance);

        if (doorR)
            doorR.localPosition = _InitialDoorR + (-_DoorDirection * _Point * openDistance);
	}
}
