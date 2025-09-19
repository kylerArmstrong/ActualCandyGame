using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
public class purchaseCandySelect : MonoBehaviour
{
    private Dictionary<string, int> candy;
    public GameObject player;

    public TMP_Text displayText;

    public int currentAmount;

    public string chosenCandy;
    public GameObject candyManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        candy = player.GetComponent<PlayerProperties>().candy;
        displayText.text = currentAmount + "";
    }

    public void chooseCandy(string cand)
    {
        chosenCandy = cand;
    }
    
     public void Increase()
    {
        if (candy[chosenCandy] > currentAmount)
        {
            currentAmount++;
            candyManager.GetComponent<candyButtonManager>().increasePurchase(chosenCandy);
            
        }
    }

    public void Decrease()
    {
        if (currentAmount > 0)
        {
            currentAmount--;
            candyManager.GetComponent<candyButtonManager>().decreasePurchase(chosenCandy);
        }
    }

}
