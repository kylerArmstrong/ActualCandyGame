using UnityEngine;

public class InteractAppear : MonoBehaviour
{
    public GameObject button;

    public bool interactable;
    public string interaction;
    
    public GameObject player;
    public GameObject uiFolder;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerControls>().interacting && interactable)
        {
            Invoke(interaction + "Enter", 0f);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        button.SetActive(true);
        interactable = true;
    }

    void OnTriggerExit(Collider other)
    {
        button.SetActive(false);
        interactable = false;
        Invoke(interaction + "Exit", 0f);
    }

    private void uiAppearEnter()
    {
        uiFolder.SetActive(true);
    }

    private void uiAppearExit()
    {
        uiFolder.SetActive(false);
    }
}
