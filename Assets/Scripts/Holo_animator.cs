using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holo_animator : MonoBehaviour
{
    public Animator Idle_animator;
    public Animator SOS_animation;

    public GameObject SOS_Screen1;
    public GameObject SOS_Screen2;

    private bool IsIdle;
    // Start is called before the first frame update
    void Start()
    {
        IsIdle = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if (!IsIdle)
        {

            if (other.tag == "Player")
            {

                IsIdle = true;
                Idle_animator.enabled = false;
                SOS_animation.enabled = true;
                SOS_Screen1.SetActive(true);
                SOS_Screen2.SetActive(true);
            }
        }
    }
}
