using UnityEngine;
using System.Collections.Generic;

public class PlayerProperties : MonoBehaviour
{

    public float money;
    public Dictionary<string, int> candy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        candy = new Dictionary<string, int>();
        candy.Add("Chocolate", 4);
        candy.Add("Lolipop", 1);
        candy.Add("Skittle", 2);
        candy.Add("Jawbreaker", 6);
        candy.Add("Gummy", 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
