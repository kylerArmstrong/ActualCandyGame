using UnityEngine;

public class InteractVisual : MonoBehaviour
{

    public Transform playerCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(-1*(playerCam.eulerAngles.x - 90), playerCam.eulerAngles.y + 180, 0);
    }
}
