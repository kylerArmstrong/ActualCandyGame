using UnityEngine;
using System.Collections.Generic;

public class PlayerProperties : MonoBehaviour
{

    public float money;
    public Dictionary<string, int> candy;
    public GameObject interactingWith;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        money = DataStorage.Instance.GetComponent<DataStorage>().money;
        candy = new Dictionary<string, int>();
        candy.Add("Chocolate", 0);
        candy.Add("Lolipop", 0);
        candy.Add("Skittle", 0);
        candy.Add("Jawbreaker", 0);
        candy.Add("Gummy", 0);
        foreach (KeyValuePair<string, int> candyPair in DataStorage.Instance.GetComponent<DataStorage>().playerCandy)
        {
            candy[candyPair.Key] = candyPair.Value;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
