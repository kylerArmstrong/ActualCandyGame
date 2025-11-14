using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InputMath : MonoBehaviour
{
    public GameObject mathManager;
    public TMP_InputField text;
    public int answer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void end()
    {
        if (text.text != "")
        {
            string input = text.text;
            int inputInt = int.Parse(input);
            answer = inputInt;

            mathManager.GetComponent<MathProblems>().correct(answer);
        }
    }
}
