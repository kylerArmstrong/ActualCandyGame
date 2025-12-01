using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class SensitivityChange : MonoBehaviour
{

    public Slider slider;
    public int sens;
    public TMP_InputField input;
    public GameObject playerCam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sens = DataStorage.Instance.GetComponent<DataStorage>().sensSave;
        input.text = sens + "";
        slider.value = sens;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void inputChange()
    {
        string sensStr = input.text;
        sens = int.Parse(sensStr);
        slider.value = sens;
        playerCam.GetComponent<PlayerCamera>().sensX = sens*45;
        playerCam.GetComponent<PlayerCamera>().sensY = sens*45;
    }

    public void sliderChange()
    {
        sens = (int)slider.value;
        input.text = sens + "";
        playerCam.GetComponent<PlayerCamera>().sensX = sens*45;
        playerCam.GetComponent<PlayerCamera>().sensY = sens*45;
    }
}
