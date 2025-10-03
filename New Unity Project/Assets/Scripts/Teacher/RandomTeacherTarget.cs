using UnityEngine;

public class RandomTeacherTarget : MonoBehaviour
{
    public GameObject area;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public float waitTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minX = area.transform.position.x - (area.transform.localScale.x/2);
        maxX = area.transform.position.x + (area.transform.localScale.x/2);
        minZ = area.transform.position.z - (area.transform.localScale.y/2);
        maxZ = area.transform.position.z + (area.transform.localScale.y/2);
        Invoke("changeSpot", waitTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeSpot()
    {
        minX = area.transform.position.x - (area.transform.localScale.x/2);
        maxX = area.transform.position.x + (area.transform.localScale.x/2);
        minZ = area.transform.position.z - (area.transform.localScale.y/2);
        maxZ = area.transform.position.z + (area.transform.localScale.y/2);
        Vector3 newSpot = new Vector3(Random.Range(minX, maxX), area.transform.position.y, Random.Range(minZ, maxZ));
        this.transform.position = newSpot;
        Invoke("changeSpot", waitTime);
    }
}
