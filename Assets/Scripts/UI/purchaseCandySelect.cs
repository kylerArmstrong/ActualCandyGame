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

    public TMP_Text priceText;
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
    
    // Must add a new if statement to both increase and decrease for the prices
     public void Increase()
    {

        currentAmount++;
        candyManager.GetComponent<candyButtonManager>().increasePurchase(chosenCandy);
        if (chosenCandy == "Chocolate")
        {
            priceText.text = int.Parse(priceText.text) + 2 + "";
        }
        else if (chosenCandy == "Lolipop")
        {
            priceText.text = int.Parse(priceText.text) + 4 + "";
        }
        else if (chosenCandy == "Skittle")
        {
            priceText.text = int.Parse(priceText.text) + 3 + "";
        }
        else if (chosenCandy == "Gum")
        {
            priceText.text = int.Parse(priceText.text) + 5 + "";
        }
        else if (chosenCandy == "Gummy")
        {
            priceText.text = int.Parse(priceText.text) + 1 + "";
        }



    }

    public void Decrease()
    {
        if (currentAmount > 0)
        {
            currentAmount--;
            candyManager.GetComponent<candyButtonManager>().decreasePurchase(chosenCandy);
            if (chosenCandy == "Chocolate")
            {
                priceText.text = int.Parse(priceText.text) - 2+ "";
            }
            else if (chosenCandy == "Lolipop")
            {
                priceText.text = int.Parse(priceText.text) - 4+ "";
            }
            else if (chosenCandy == "Skittle")
            {
                priceText.text = int.Parse(priceText.text) - 3+ "";
            }
            else if (chosenCandy == "Gum")
            {
                priceText.text = int.Parse(priceText.text) - 5+ "";
            }
            else if (chosenCandy == "Gummy")
            {
                priceText.text = int.Parse(priceText.text) - 1+ "";
            }
        }
    }

}
