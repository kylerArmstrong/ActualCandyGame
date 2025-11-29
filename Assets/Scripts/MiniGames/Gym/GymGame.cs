using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GymGame : MonoBehaviour
{
    public float timer;
    public TMP_Text timerText;
    public bool started;
    public TMP_Text directionText;
    public int score;
    public TMP_Text scoreText;
    public bool registerInput;

    public float totalTimer;
    public TMP_Text totalTimerText;

    public GameObject startGymGame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        registerInput = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        totalTimer -= Time.deltaTime;
        totalTimerText.text = ((int)totalTimer) + "";
        timerText.text = ((int)timer) + "";
        if(timer <= 0 && !started)
        {
            started = true;
            totalTimerText.gameObject.SetActive(true);
            newDirection();
        }
        if(Input.anyKeyDown && registerInput)
        {
            if (directionText.text == "Left")
            {
                if (Input.GetKey(KeyCode.A))
                {
                    correct();
                }
                else
                {
                    incorrect();
                }
            }
            else if (directionText.text == "Right")
            {
                if (Input.GetKey(KeyCode.D))
                {
                    correct();
                }
                else
                {
                    incorrect();
                }
            }
            else if (directionText.text == "Forward")
            {
                if (Input.GetKey(KeyCode.W))
                {
                    correct();
                }
                else
                {
                    incorrect();
                }
            }
            else if (directionText.text == "Backward")
            {
                if (Input.GetKey(KeyCode.S))
                {
                    correct();
                }
                else
                {
                    incorrect();
                }
            }
            else if (directionText.text == "Jump")
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    correct();
                }
                else
                {
                    incorrect();
                }
            }
            
        }
        if(totalTimer <= 0)
        {
            if(registerInput)
            {
                end();
            }
            else
            {
                if(timer <= 0)
                {
                    directionText.text = "Press any key to Leave";
                    if(Input.anyKeyDown)
                    {
                        directionText.text = "";
                        directionText.gameObject.SetActive(false);
                        timerText.gameObject.SetActive(true);
                        startGymGame.GetComponent<StartGymGame>().StopGame();
                    }
                }
            }
        }
        
    }

    public void OnEnable()
    {
        timer = 4;
        totalTimer = 35;
        started = false;
    }

    public void newDirection()
    {
        timerText.gameObject.SetActive(false);
        directionText.gameObject.SetActive(true);
        timer = 1;
        int rand = Random.Range(1, 6);
        if(rand == 1)
        {
            directionText.text = "Left";
        }
        else if (rand == 2)
        {
            directionText.text = "Right";
        }
        else if (rand == 3)
        {
            directionText.text = "Forward";
        }
        else if (rand == 4)
        {
            directionText.text = "Backward";
        }
        else if (rand == 5)
        {
            directionText.text = "Jump";
        }
    }

    public void correct()
    {
        if(timer > 0.1)
        {
            score += (int)(timer * 1000);
        }
        else
        {
            score += 100;
        }
        scoreText.text = "Score: " + score;
        newDirection();
    }

    public void incorrect()
    {
        score -= 250;
        scoreText.text = "Score: " + score;
    }

    public void end()
    {
        totalTimerText.gameObject.SetActive(false);
        directionText.text = "";
        registerInput = false;
        timer = 1;
    }
}
