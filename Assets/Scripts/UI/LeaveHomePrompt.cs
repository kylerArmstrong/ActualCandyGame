using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaveHomePrompt : MonoBehaviour
{

    public GameObject uiFolder;
    public GameObject player;
    public GameObject sensSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void yes()
    {
        loadStuff();
        SceneManager.LoadScene("Game");
    }

    public void no()
    {
        player.GetComponent<PlayerControls>().interacting = false;
        uiFolder.SetActive(false);
    }

    public void loadStuff()//make sure it is same as Schedule.cs load stuff
    {
        DataStorage.Instance.GetComponent<DataStorage>().playerInventory(player.GetComponent<PlayerProperties>().candy);
        DataStorage.Instance.GetComponent<DataStorage>().saveMoney(player.GetComponent<PlayerProperties>().money);
        DataStorage.Instance.GetComponent<DataStorage>().saveSens(sensSlider.GetComponent<SensitivityChange>().sens);
    }
}
