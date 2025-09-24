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
    public bool interacting;
    public bool notChanged;
    public bool purchase;

    public GameObject purchaseConfirmBut;
    

    void Start()
    {
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
            if (!purchase)
            {
                notChanged = true;
                foreach (KeyValuePair<string, int> candyPair in candy)
                {
                    if (candyPair.Value != candyBargain[candyPair.Key])
                    {
                        priceInput.GetComponent<InputPrice>().hasCandy = true;
                        notChanged = false;
                    }
                }
                if (notChanged)
                {
                    priceInput.GetComponent<InputPrice>().hasCandy = false;
                }
            }
            else
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
    }

    public void decreaseBargain(string chosenCandy)
    {
        candyBargain[chosenCandy]++;
    }

    public void increasePurchase(string chosenCandy)
    {
        candyBargain[chosenCandy]++;
    }

    public void decreasePurchase(string chosenCandy)
    {
        candyBargain[chosenCandy]--;
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
