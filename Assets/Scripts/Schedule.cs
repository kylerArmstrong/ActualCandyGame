using UnityEngine;
using UnityEngine.SceneManagement;

public class Schedule : MonoBehaviour
{
    public string[] periods;
    public string currentPeriod;
    public float timeLeft;
    public float timePerPeriod;
    public float timeBetweenPeriods;
    public int inc;
    public GameObject player;
    public GameObject sensSlider;
    public GameObject scheduleText;
    public GameObject holder;
    public GameObject leaveSchoolUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDay();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            timeLeft = 99999f;
            nextPeriod();

        }
    }

    public void nextPeriod()
    {
        inc++;
        currentPeriod = "passing";
        Invoke("next", timeBetweenPeriods);
    }

    private void next()
    {
        
        currentPeriod = periods[inc];
        scheduleText.GetComponent<ScheduleDisplay>().UpdateScheduleText();
        if(currentPeriod == "Home")
        {
            //loadStuff();
            holder.SetActive(true);
            leaveSchoolUI.SetActive(true);
        }
        else
        {
            timeLeft = timePerPeriod;  
        }
        
    }

    public void loadStuff()//make sure it is same as LeaveHomePrompt.cs load stuff
    {
        DataStorage.Instance.GetComponent<DataStorage>().playerInventory(player.GetComponent<PlayerProperties>().candy);
        DataStorage.Instance.GetComponent<DataStorage>().saveMoney(player.GetComponent<PlayerProperties>().money);
        DataStorage.Instance.GetComponent<DataStorage>().saveSens(sensSlider.GetComponent<SensitivityChange>().sens);
    }


    public void StartDay()
    {
        inc = 0;
        currentPeriod = periods[inc];
        timeLeft = timePerPeriod;
        scheduleText.GetComponent<ScheduleDisplay>().UpdateScheduleText();
    }
}
