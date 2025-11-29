using UnityEngine;

public class StartGymGame : MonoBehaviour
{
    public GameObject gymGame;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gymGame.SetActive(true);
        player.GetComponent<PlayerControls>().interacting = true;

    }

    public void StopGame()
    {
        gymGame.SetActive(false);
        player.GetComponent<PlayerControls>().interacting = false;
    }
}
