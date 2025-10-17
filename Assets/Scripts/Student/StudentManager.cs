using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class StudentManager : MonoBehaviour
{
    public string location;
    public TMP_Text locationText;
    public TMP_Text nameText;
    public Dictionary<string, GameObject> students;
    public GameObject bob;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        students = new Dictionary<string, GameObject>();

        students.Add("Bob", bob);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chooseNewLocation()
    {
        location = locationText.text;
    }

    public void confirm()
    {
        students[nameText.text].GetComponent<StudentMovement>().setDeal(location);
    }
}
