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

    public GameObject p1Door;
    public GameObject p1Seat;
    public GameObject p2Door;
    public GameObject p2Seat;
    public GameObject lunchDoor;
    public GameObject gymDoor;
    public GameObject mat;
    public GameObject p5Door;
    public GameObject p5Seat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartDay();
        p1Door.SetActive(false);
        p1Seat.SetActive(false);
        p2Door.SetActive(false);
        p2Seat.SetActive(false);
        lunchDoor.SetActive(false);
        gymDoor.SetActive(false);
        mat.SetActive(false);
        p5Door.SetActive(false);
        p5Seat.SetActive(false);
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

        if(inc == 0)
        {
            p1Door.SetActive(true);
            p1Seat.SetActive(true);
            p2Door.SetActive(false);
            p2Seat.SetActive(false);
            lunchDoor.SetActive(false);
            gymDoor.SetActive(false);
            mat.SetActive(false);
            p5Door.SetActive(false);
            p5Seat.SetActive(false);
        }
        else if (inc == 1)
        {
            p1Door.SetActive(false);
            p1Seat.SetActive(false);
            p2Door.SetActive(true);
            p2Seat.SetActive(true);
            lunchDoor.SetActive(false);
            gymDoor.SetActive(false);
            mat.SetActive(false);
            p5Door.SetActive(false);
            p5Seat.SetActive(false);
        }
        else if (inc == 2)
        {
            p1Door.SetActive(false);
            p1Seat.SetActive(false);
            p2Door.SetActive(false);
            p2Seat.SetActive(false);
            lunchDoor.SetActive(true);
            gymDoor.SetActive(false);
            mat.SetActive(false);
            p5Door.SetActive(false);
            p5Seat.SetActive(false);
        }
        else if (inc == 3)
        {
            p1Door.SetActive(false);
            p1Seat.SetActive(false);
            p2Door.SetActive(false);
            p2Seat.SetActive(false);
            lunchDoor.SetActive(false);
            gymDoor.SetActive(true);
            mat.SetActive(true);
            p5Door.SetActive(false);
            p5Seat.SetActive(false);
        }
        else if (inc == 4)
        {
            p1Door.SetActive(false);
            p1Seat.SetActive(false);
            p2Door.SetActive(false);
            p2Seat.SetActive(false);
            lunchDoor.SetActive(false);
            gymDoor.SetActive(false);
            mat.SetActive(false);
            p5Door.SetActive(true);
            p5Seat.SetActive(true);
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
        inc = -2;

        nextPeriod();
        scheduleText.GetComponent<ScheduleDisplay>().UpdateScheduleText();
    }
}
