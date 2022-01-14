using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Photon.Pun;

public class RodHandler : MonoBehaviourPunCallbacks
{
    [SerializeField] public string rodNameSetter;
    [SerializeField] private List<GameObject> Rods;
    [SerializeField] private GameObject coreSphere;
    [SerializeField] private ParticleSystem coreSmoke;
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _source1;
    [SerializeField] private AudioClip _audioClip1;
    [SerializeField] private AudioSource _source2;
    [SerializeField] private AudioClip _audioClip2;
    [SerializeField] private AudioSource _source3;
    [SerializeField] private AudioClip _audioClip3;
    [SerializeField] private TextMeshProUGUI _textCount;

    [SerializeField] private int _sequenceCounter = 0;


    [SerializeField] private string rightSequence;

    [SerializeField] private string currentSequence;

    [SerializeField] private ProgressManager _ProgressManager;
    [SerializeField] private ExitGames.Client.Photon.Hashtable _SequenceCounterProp = new ExitGames.Client.Photon.Hashtable();


    private void Start()
    {
        _sequenceCounter = 1;
        rightSequence = "162233";
        _textCount.text = _sequenceCounter.ToString();

        currentSequence = "";
        _SequenceCounterProp["SequenceCounter"] = _sequenceCounter;
        _SequenceCounterProp["CurrentSequence"] = currentSequence;
        PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceCounterProp);

    }
    private void Update()
    {
        if (rodNameSetter != "")
        {
            coreSphere.GetComponent<Light>().color = Color.blue;
            coreSmoke.GetComponent<ParticleSystem>().startColor = Color.blue;
            AddRodToSequence(rodNameSetter);
            
        }
        if (_sequenceCounter == 2)
        {
            rightSequence = "122436";
            _textCount.text = _sequenceCounter.ToString();
            print("sequentie 2 nu");
        }
        if (_sequenceCounter == 3)
        {
            
            rightSequence = "132331";
            _textCount.text = _sequenceCounter.ToString();
            print("sequentie 3 nu");
        }
        if(_sequenceCounter == 4)
        {
            _ProgressManager.RoomFixed(4);
            print("core fixed");
        }
     
    }

    public override void OnRoomPropertiesUpdate(ExitGames.Client.Photon.Hashtable property)
    {
        Debug.Log(property);
        if (property.ContainsKey("SequenceCounter"))
        {
            _sequenceCounter = (int)PhotonNetwork.CurrentRoom.CustomProperties["SequenceCounter"];
        }
        if (property.ContainsKey("CurrentSequence"))
        {
            currentSequence = (string)PhotonNetwork.CurrentRoom.CustomProperties["CurrentSequence"];
            CheckSequence();
        }
    }

    //switch case met de corresponderende rod code die naar de currentsequence schrijft
    void AddRodToSequence(string rodNumber)
    {
        switch (rodNumber)
        {
            case "1a":
                if (!currentSequence.Contains("11"))
                {
                    currentSequence += 11;
                    rodNameSetter = "";
                }
                break;
            case "1b":
                if(!currentSequence.Contains("12"))
                {
                    currentSequence += 12;
                    rodNameSetter = "";
                }
                break;
            case "1c":
                if (!currentSequence.Contains("13"))
                {
                    currentSequence += 13;
                    rodNameSetter = "";
                }
                break;
            case "1d":
                if (!currentSequence.Contains("14"))
                {
                    currentSequence += 14;
                    rodNameSetter = "";
                }
                break;
            case "1e":
                if (!currentSequence.Contains("15"))
                {
                    currentSequence += 15;
                    rodNameSetter = "";
                }
                break;
            case "1f":
                if (!currentSequence.Contains("16"))
                {
                    currentSequence += 16;
                    rodNameSetter = "";
                }
                break;
            case "2a":
                if (!currentSequence.Contains("21"))
                {
                    currentSequence += 21;
                    rodNameSetter = "";
                }
                break;
            case "2b":
                if (!currentSequence.Contains("22"))
                {
                    currentSequence += 22;
                    rodNameSetter = "";
                }
                break;
            case "2c":
                if (!currentSequence.Contains("23"))
                {
                    currentSequence += 23;
                    rodNameSetter = "";
                }
                break;
            case "2d":
                if (!currentSequence.Contains("24"))
                {
                    currentSequence += 24;
                    rodNameSetter = "";
                }
                break;
            case "2e":
                if (!currentSequence.Contains("25"))
                {
                    currentSequence += 25;
                    rodNameSetter = "";
                }
                break;
            case "2f":
                if (!currentSequence.Contains("26"))
                {
                    currentSequence += 26;
                    rodNameSetter = "";
                }
                break;
            case "3a":
                if (!currentSequence.Contains("31"))
                {
                    currentSequence += 31;
                    rodNameSetter = "";
                }
                break;
            case "3b":
                if (!currentSequence.Contains("32"))
                {
                    currentSequence += 32;
                    rodNameSetter = "";
                }
                break;
            case "3c":
                if (!currentSequence.Contains("33"))
                {
                    currentSequence += 33;
                    rodNameSetter = "";
                }
                break;
            case "3d":
                if (!currentSequence.Contains("34"))
                {
                    currentSequence += 34;
                    rodNameSetter = "";
                }
                break;
            case "3e":
                if (!currentSequence.Contains("35"))
                {
                    currentSequence += 35;
                    rodNameSetter = "";
                }
                break;
            case "3f":
                if (!currentSequence.Contains("36"))
                {
                    currentSequence += 36;
                    rodNameSetter = "";
                }
                break;
        }

        _SequenceCounterProp["CurrentSequence"] = currentSequence;
        PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceCounterProp);

        CheckSequence();
    }

    void CheckSequence()
    {
        //kijkt op de currentsequence niet hetzelfde is als de rightsequence lengte van de currentsequence
        //zo nee start de functie wrongsequence
        if (currentSequence.Length == 6)
        {
            if (currentSequence == rightSequence)
            {
                currentSequence = "";
                coreSphere.GetComponent<Light>().color = Color.green;
                coreSmoke.GetComponent<ParticleSystem>().startColor = Color.green;
                _sequenceCounter++;

                _SequenceCounterProp["CurrentSequence"] = currentSequence;
                PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceCounterProp);

                _SequenceCounterProp["SequenceCounter"] = _sequenceCounter;
                PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceCounterProp);

                if (_sequenceCounter == 2)
                {
                    _source1.PlayOneShot(_audioClip1);
                }
                if (_sequenceCounter == 3)
                {
                    _source2.PlayOneShot(_audioClip2);
                }
                if (_sequenceCounter == 4)
                {
                    _source3.PlayOneShot(_audioClip3);
                }
                wrongSequence();
                print("core gaat naar volgende sequentie");
            }
            else
            {
                currentSequence = "";
                coreSphere.GetComponent<Light>().color = Color.red;
                coreSmoke.GetComponent<ParticleSystem>().startColor = Color.red;
                wrongSequence();
                _source.PlayOneShot(_audioClip);
                print("lekker man nu is alles kapot");

                _SequenceCounterProp["CurrentSequence"] = currentSequence;
                PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceCounterProp);
            }
        }
        else if (currentSequence.Length > 6)
        {
            currentSequence = "";
            coreSphere.GetComponent<Light>().color = Color.red;
            coreSmoke.GetComponent<ParticleSystem>().startColor = Color.red;
            wrongSequence();
            _source.PlayOneShot(_audioClip);
            print("lekker man nu is alles kapot");

            _SequenceCounterProp["CurrentSequence"] = currentSequence;
            PhotonNetwork.CurrentRoom.SetCustomProperties(_SequenceCounterProp);
        }
    }

    //maakt een objarray met alle rods, gaat vervolgens per array de rigidbody terug zetten
    //de boolean is pressed terug zetten naar false
    //en het script ResetPosition starten in het script van de rods
    void wrongSequence()
    {
        rodNameSetter = "";
        
        foreach(GameObject rod in Rods)
        {
            rod.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            CoreRodController script = rod.GetComponent<CoreRodController>();
            script.isPressed = false;
            script.ResetPosition();
            
        }
    }
}
