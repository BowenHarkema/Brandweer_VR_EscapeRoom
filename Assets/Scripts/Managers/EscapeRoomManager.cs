using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EscapeRoomManager : MonoBehaviour
{
    public float TimerLength;
    public List<TextMeshProUGUI> TimeDisplays;
    private bool TimerRunning;
    // Start is called before the first frame update
    void Start()
    {
        TimerRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerRunning)
        {
            TimerLength = TimerLength - Time.deltaTime;
            DisplayTimeLeft();
        }
    }
    public void DisplayTimeLeft()
    {
        int TimeLeft = (int)TimerLength;
        int minutes = TimeLeft / 60;
        int Seconds = TimeLeft - (minutes * 60);
        Debug.Log(Seconds);
        
        foreach(TextMeshProUGUI display in TimeDisplays)
        {
            display.text = minutes + ":" + Seconds;
        }
       
    }
}
