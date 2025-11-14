using UnityEngine;

public class SitDown : MonoBehaviour
{

    public GameObject player;
    public GameObject mathGame;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<PlayerControls>().sitting)
        {
            if(Input.GetKey(player.GetComponent<PlayerControls>().jumpKey))
            {
                stand();
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sit();
        }
    }

    public void sit()
    {
        //set a bool on player script to false that disables movement (allows jump to exit seat)
        //puts player into the seat
        player.GetComponent<PlayerControls>().sitting = true;
        player.GetComponent<Rigidbody>().isKinematic = true;
        player.GetComponent<Rigidbody>().detectCollisions = false;
        player.transform.position = this.transform.position + new Vector3(0, 1, 0);
        mathGame.SetActive(true);
        player.GetComponent<PlayerControls>().interacting = true;

    }

    public void stand()
    {
        player.GetComponent<PlayerControls>().sitting = false;
        player.GetComponent<Rigidbody>().isKinematic = false;
        mathGame.SetActive(false);
        player.GetComponent<PlayerControls>().interacting = false;
        Invoke("col", 0.5f);
    }

    public void col()
    {
        player.GetComponent<Rigidbody>().detectCollisions = true;
    }
}
