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
    public GameObject jim;
    public GameObject john;
    public GameObject fred;
    public GameObject cooper;
    public GameObject joe;
    public GameObject alex;
    public GameObject nolan;
    public GameObject ethan;
    public GameObject aidan;
    public GameObject melissa;
    public GameObject kate;
    public GameObject natalie;
    public GameObject lauren;
    public GameObject hannah;
    public GameObject kristen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        students = new Dictionary<string, GameObject>();

        students.Add("Bob", bob);
        students.Add("Jim", jim);
        students.Add("John", john);
        students.Add("Fred", fred);
        students.Add("Cooper", cooper);
        students.Add("Joe", joe);
        students.Add("Alex", alex);
        students.Add("Nolan", nolan);
        students.Add("Ethan", ethan);
        students.Add("Aidan", aidan);
        students.Add("Melissa", melissa);
        students.Add("Kate", kate);
        students.Add("Natalie", natalie);
        students.Add("Lauren", lauren);
        students.Add("Hannah", hannah);
        students.Add("Kristen", kristen);
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
