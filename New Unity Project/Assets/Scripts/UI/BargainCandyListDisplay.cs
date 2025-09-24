using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class BargainCandyListDisplay : MonoBehaviour
{

    public TMP_Text candyText;
    public GameObject player;

    private Dictionary<string, int> candy;
    public GameObject buttonSet;
    public GameObject candyManager;
    public Transform buttonSetPos;

    public TMP_Text priceText;
    public bool purchase;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEnable()
    {
        Debug.Log("enable");
        if(player.GetComponent<PlayerControls>().interacting == false)
        {
            Debug.Log("change");
            change();
        }
    }

    public void change()
    {
        int positionCount = 0;
        candyText.text = "";
        candy = player.GetComponent<PlayerProperties>().candy;
        foreach (KeyValuePair<string, int> candyPair in candy)
        {
            Debug.Log("go");
            candyText.text += candyPair.Key + ": \n";
            //make a button set even with it
            Vector3 temp = buttonSetPos.position;
            temp.y = temp.y + (positionCount * -43);//change the # to change the offset of the buttons
            GameObject but = Instantiate(buttonSet, temp, buttonSetPos.rotation, buttonSetPos);
            if (purchase)
            {
                but.GetComponent<purchaseCandySelect>().chosenCandy = candyPair.Key;
                but.GetComponent<purchaseCandySelect>().candyManager = candyManager;
                but.GetComponent<purchaseCandySelect>().priceText = priceText;
            }
            else
            {
                but.GetComponent<CandySelect>().chosenCandy = candyPair.Key;
                but.GetComponent<CandySelect>().candyManager = candyManager;
                
            }
            positionCount++;
        }
    }
}
