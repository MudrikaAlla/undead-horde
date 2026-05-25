using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

public class Timer : MonoBehaviour
{
    public float time = 0;
    [SerializeField] private TextMeshProUGUI timeElement;

    void Start()
    {

    }

    void Update()
    {
        //incrementing the time
        time += Time.deltaTime;
        //displaying the time
        DisplayTime(time);
    }

    //method to display time on screen
    void DisplayTime(float time)
    {
        //claculating minutes and seconds from the remaining time 
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        //displaying the time using text mesh pro
        timeElement.text = string.Format("Timer: {0:00}:{1:00}", minutes, seconds);
    }
}
