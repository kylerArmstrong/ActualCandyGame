using UnityEngine;

public class RandomTeacherTarget : MonoBehaviour
{
    public GameObject area;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minX = area.transform.position.x - (area.transform.localScale.x/2);
        maxX = area.transform.position.x + (area.transform.localScale.x/2);
        minZ = area.transform.position.z - (area.transform.localScale.y/2);
        maxZ = area.transform.position.z + (area.transform.localScale.y/2);
        Invoke("changeSpot", 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeSpot()
    {
        Vector3 newSpot = new Vector3(Random.Range(minX, maxX), area.transform.position.y, Random.Range(minZ, maxZ));
        this.transform.position = newSpot;
        Invoke("changeSpot", 5f);
    }
}
