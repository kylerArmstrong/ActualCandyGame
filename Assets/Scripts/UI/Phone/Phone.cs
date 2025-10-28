using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject appsScreen;
    public GameObject app;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openApp()
    {
        app.SetActive(true);
        appsScreen.SetActive(false);
    }


    public void closeApp()
    {
        app.SetActive(false);
        appsScreen.SetActive(true);
    }

}
