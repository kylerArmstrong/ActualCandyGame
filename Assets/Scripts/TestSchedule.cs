using UnityEngine;

public class TestSchedule : MonoBehaviour
{

    public string[] periods;
    public string currentPeriod;
    public int inc; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPeriod = periods[inc];
    }
}
