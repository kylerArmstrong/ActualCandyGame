using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class CustomerDisplay : MonoBehaviour
{
    public GameObject student;
    public string name;
    public string location;
    public TMP_Text nameText;
    public TMP_Text locText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnEnable()
    {
        name = student.GetComponent<StudentProperties>().name;
        location = student.GetComponent<StudentProperties>().location;
        locText.text = location;
        nameText.text = name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void confirm()
    {
        student.GetComponent<StudentMovement>().setDeal(location);
    }
}
