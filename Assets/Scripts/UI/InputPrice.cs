using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;


public class InputPrice : MonoBehaviour
{

    public TMP_InputField text;

    private Dictionary<string, int> candy;
    public Dictionary<string, int> candyPurchase;
    public GameObject player;
    public GameObject bargainUiFolder;
    public int price;
    public GameObject candyButManager;
    public bool hasCandy;
    public GameObject customer;
    public float marketSalePrice;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public void End()
    {
        //something wrong with text.text it works with "#"
        if (text.text != "")
        {
            string input = text.text;
            int inputInt = int.Parse(input);
            price = inputInt;

        }
    }

    public void confirm()
    {
        if (text.text != "" && hasCandy && notOutrageous())
        {
            player.GetComponent<PlayerProperties>().money += price;
            player.GetComponent<PlayerControls>().interacting = false;
            bargainUiFolder.SetActive(false);
            candyButManager.GetComponent<candyButtonManager>().sale();
            hasCandy = false;
            customer.GetComponent<StudentMovement>().mode = "learn";
            
        }


    }

    public bool notOutrageous()
    {
        candyButManager.GetComponent<candyButtonManager>().getMarketPrice();
        if(marketSalePrice * .7 < price && price < marketSalePrice * 1.3)
        {
            return true;
        }
        return false;
    }


}
