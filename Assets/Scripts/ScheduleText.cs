using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ScheduleText : MonoBehaviour
{
    public GameObject Schedule;
    public TMP_Text text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = Schedule.GetComponent<Schedule>().currentPeriod;
    }
}
