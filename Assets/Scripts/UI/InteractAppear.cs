using UnityEngine;

public class InteractAppear : MonoBehaviour
{
    public GameObject button;

    public bool interactable;
    public string interaction;
    
    public GameObject player;
    public GameObject uiFolder;

    public bool changeInteracting;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        changeInteracting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerControls>().interactKeyDown && interactable)
        {
            Invoke(interaction + "Enter", 0f);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            button.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            button.SetActive(false);
            interactable = false;
            if(this.transform.parent.transform.parent.gameObject == player.GetComponent<PlayerProperties>().interactingWith)//if the player is interacting with this hitbox
            {
                changeInteracting = true;
            }
            else
            {
                changeInteracting = false;
            }
            Invoke(interaction + "Exit", 0f);
        }
    }

    public void uiAppearEnter()
    {
       
        uiFolder.SetActive(true);
        player.GetComponent<PlayerControls>().interacting = true;
        player.GetComponent<PlayerProperties>().interactingWith = this.transform.parent.transform.parent.gameObject;//first parent is the button folder second one is the actual object
    }

    public void uiAppearExit()
    {
        if(changeInteracting == true)
        {
            player.GetComponent<PlayerControls>().interacting = false;
        }
        uiFolder.SetActive(false);
    }
}
