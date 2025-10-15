using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyDisplay : MonoBehaviour
{
    public GameObject player;

    private float money;
    public TMP_Text moneyText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        money = player.GetComponent<PlayerProperties>().money;
        moneyText.text = "$ " + money;
    }
}
