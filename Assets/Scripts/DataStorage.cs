using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DataStorage : MonoBehaviour
{
    public static DataStorage Instance; 

    
    public Dictionary<string, int> playerCandy;
    public float money;
    public int sensSave;

    void Awake()
    {
        if (Instance != null)
        {
            money = DataStorage.Instance.GetComponent<DataStorage>().money;
            playerCandy = DataStorage.Instance.GetComponent<DataStorage>().playerCandy;
            sensSave = DataStorage.Instance.GetComponent<DataStorage>().sensSave;
            Destroy(gameObject);
            return;
        }
    // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void playerInventory(Dictionary<string, int> candy)//saves data for candy
    {
        playerCandy = candy;
    }

    public void saveMoney(float saveMoney)
    {
        money = saveMoney;
    }

    public void saveSens(int sens)
    {
        sensSave = sens;
    }

    //link to tutorial https://learn.unity.com/tutorial/implement-data-persistence-between-scenes
}
