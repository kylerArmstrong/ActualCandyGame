using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BargainCandyListDisplay : MonoBehaviour
{

    public TMP_Text candyText;
    public GameObject player;

    private Dictionary<string, int> candy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        candyText.text = "";
        candy = player.GetComponent<PlayerProperties>().candy;
        foreach(KeyValuePair<string, int> candyPair in candy)
        {
            candyText.text += candyPair.Key + ": \n";
        }
    }
}
