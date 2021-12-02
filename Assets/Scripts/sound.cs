using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound : MonoBehaviour
{
    [SerializeField] private AudioSource _source;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private ParticleSystem _confetti;

    [SerializeField] private List<AudioClip> _AudioList;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;

    }

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {

        _source.PlayOneShot(_AudioList[Random.Range(0, _AudioList.Count)]);
        _confetti.Play();
    }
    // Make sure that deathzone has a collider, box, or mesh.. ect..,
    // Make sure to turn "off" collider trigger for your deathzone Area;
    // Make sure That anything that collides into deathzone, is rigidbody;
}
