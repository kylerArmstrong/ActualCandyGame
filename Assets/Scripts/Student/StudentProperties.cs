using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class StudentProperties : MonoBehaviour
{
    public string name;
    public string location;
    public TMP_Text locationText;
    public TMP_Text nameText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseNewLocation()
    {
        if(nameText.text == name)
        {
            location = locationText.text;

        }
    }
}
