using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ScheduleDisplay : MonoBehaviour
{
    public TMP_Text text;
    public GameObject Schedule;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScheduleText()
    {
        if(Schedule.GetComponent<Schedule>().currentPeriod == "Science")
        {
            text.text = "Science <-\nEnglish \nLunch \nGym \nMath";
        } 
        else if(Schedule.GetComponent<Schedule>().currentPeriod == "English")
        {
            text.text = "Science \nEnglish <-\nLunch \nGym \nMath";
        } 
        else if(Schedule.GetComponent<Schedule>().currentPeriod == "Lunch")
        {
            text.text = "Science \nEnglish \nLunch <-\nGym \nMath";
        } 
        else if(Schedule.GetComponent<Schedule>().currentPeriod == "Gym")
        {
            text.text = "Science \nEnglish \nLunch \nGym <-\nMath";
        } 
        else if(Schedule.GetComponent<Schedule>().currentPeriod == "Math")
        {
            text.text = "Science \nEnglish \nLunch \nGym \nMath <-";
        } 
        else if(Schedule.GetComponent<Schedule>().currentPeriod == "Home")
        {
            text.text = "Go Home";
        }
        
    }
}
