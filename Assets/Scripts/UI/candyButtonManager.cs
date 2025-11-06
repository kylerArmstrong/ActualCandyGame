using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class candyButtonManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Dictionary<string, int> candy;
    public Dictionary<string, int> candyBargain;

    public Dictionary<string, int> candyPurchase;
    public GameObject priceInput;
    public GameObject player;
    public GameObject customer;
    public bool interacting;
    public bool notChanged;
    public bool purchase;

    public float marketPrice;

    public GameObject purchaseConfirmBut;
    

    void OnEnable()
    {
        //sets candy bargain to the candy dictionary in the player
        candy = player.GetComponent<PlayerProperties>().candy;
        candyBargain = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> candyPair in candy)
        {
            candyBargain.Add(candyPair.Key, candyPair.Value);
        }
    }

    // Update is called once per frame
    void Update()
    {

        interacting = player.GetComponent<PlayerControls>().interacting;

        if (interacting)
        {
            if (!purchase)//for bargain
            {
                notChanged = true;
                foreach (KeyValuePair<string, int> candyPair in candy)
                {
                    if (candyPair.Value != candyBargain[candyPair.Key])
                    {
                        priceInput.GetComponent<InputPrice>().hasCandy = true;
                        notChanged = false;
                        priceInput.GetComponent<InputPrice>().customer = player.GetComponent<PlayerProperties>().interactingWith;
                    }
                }
                if (notChanged)
                {
                    priceInput.GetComponent<InputPrice>().hasCandy = false;
                }
            }
            else//for purchase
            {
                notChanged = true;
                foreach (KeyValuePair<string, int> candyPair in candy)
                {
                    if (candyPair.Value != candyBargain[candyPair.Key])
                    {
                        purchaseConfirmBut.GetComponent<PurchaseConfirm>().hasCandy = true;
                        notChanged = false;
                    }
                }
                if (notChanged)
                {
                    purchaseConfirmBut.GetComponent<PurchaseConfirm>().hasCandy = false;
                }
            }
        }
        
        
    }

    public void increaseBargain(string chosenCandy)
    {
        candyBargain[chosenCandy]--;
        if (chosenCandy == "Chocolate")
        {
            marketPrice += 2.4f;
        }
        else if (chosenCandy == "Lolipop")
        {
            marketPrice += 1.2f;
        }
        else if (chosenCandy == "Skittle")
        {
            marketPrice += 3.6f;
        }
        else if (chosenCandy == "Jawbreaker")
        {
            marketPrice += 6f;
        }
        else if (chosenCandy == "Gummy")
        {
            marketPrice += 1.2f;
        }
        //priceInput.GetComponent<InputPrice>().marketSalePrice += chosenCandy.price?
    }

    public void decreaseBargain(string chosenCandy)
    {
        candyBargain[chosenCandy]++;
        if (chosenCandy == "Chocolate")
        {
            marketPrice -= 2.4f;
        }
        else if (chosenCandy == "Lolipop")
        {
            marketPrice -= 1.2f;
        }
        else if (chosenCandy == "Skittle")
        {
            marketPrice -= 3.6f;
        }
        else if (chosenCandy == "Jawbreaker")
        {
            marketPrice -= 6f;
        }
        else if (chosenCandy == "Gummy")
        {
            marketPrice -= 1.2f;
        }
    }

    public void increasePurchase(string chosenCandy)
    {
        candyBargain[chosenCandy]++;
    }

    public void decreasePurchase(string chosenCandy)
    {
        candyBargain[chosenCandy]--;
    }

    public void getMarketPrice()
    {
       
        priceInput.GetComponent<InputPrice>().marketSalePrice = marketPrice;
    }

    public void sale()
    {

        
        player.GetComponent<PlayerProperties>().candy = candyBargain;
        candy = player.GetComponent<PlayerProperties>().candy;
        candyBargain = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> candyPair in candy)
        {
            candyBargain.Add(candyPair.Key, candyPair.Value);
        }
    }

    
}
