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
        candy.Add("chocolate", 4);
        Debug.Log(candy["chocolate"]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
