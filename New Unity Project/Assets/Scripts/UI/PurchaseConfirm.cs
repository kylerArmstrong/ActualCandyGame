using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class PurchaseConfirm : MonoBehaviour
{
    public TMP_Text text;

    private Dictionary<string, int> candy;
    public Dictionary<string, int> candyPurchase;
    public GameObject player;
    public GameObject purchaseUiFolder;
    public int price;
    public GameObject candyButManager;
    public bool hasCandy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (text.text != "")
        {
            string input = text.text;
            int inputInt = int.Parse(input);
            price = inputInt;

        }
    }

    public void confirm()
    {
        if (text.text != "" && hasCandy && player.GetComponent<PlayerProperties>().money - price >= 0)
        {
            player.GetComponent<PlayerProperties>().money -= price;
            player.GetComponent<PlayerControls>().interacting = false;
            purchaseUiFolder.SetActive(false);
            candyButManager.GetComponent<candyButtonManager>().sale();
            hasCandy = false;
            text.text = "0";
        }
    }
}
