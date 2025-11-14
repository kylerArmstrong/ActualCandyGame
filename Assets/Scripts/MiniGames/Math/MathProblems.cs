using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class MathProblems : MonoBehaviour
{

    public Dictionary<string, int> problems;
    public float totalProblems;
    public float correctProblems;

    public string currentProblem;
    public TMP_Text problemText;
    public int maxProblems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        //add a new one for each problem
        problems = new Dictionary<string, int>();
        problems.Add("5 + 2", 7);
        problems.Add("2 + 3", 5);
        problems.Add("11 - 4", 7);
        problems.Add("6 + 7", 13);
        maxProblems = Random.Range(5, 20);
        correctProblems = 0;
        totalProblems = 0;
        chooseNextProblem();
    }

    public void chooseNextProblem()
    {
        //should choose a random problem
        int rand = Random.Range(0, problems.Count);
        int inc = -1;
        foreach(KeyValuePair<string, int> probPair in problems)
        {
            if(inc < rand)
            {
                currentProblem = probPair.Key;
            }
            inc++;
        }
        problemText.text = currentProblem;
    }

    public void correct(int answer)
    {
        if(answer == problems[currentProblem])
        {
            correctProblems++;
        }
        totalProblems++;
        if(totalProblems == maxProblems)
        {
            problemText.text = "You got a: " + correctProblems + "/" + totalProblems + "\n" + (correctProblems/totalProblems) * 100 + "%";
        }
        else
        {
            chooseNextProblem();
        }
    }
}
