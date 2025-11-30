using UnityEngine;
using UnityEngine.SceneManagement;

public class sentHome : MonoBehaviour
{
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
        Invoke("home", 2f);
    }

    public void home()
    {
        SceneManager.LoadScene("Home");
    }
}
