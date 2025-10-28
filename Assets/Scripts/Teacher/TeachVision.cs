using UnityEngine;

public class TeachVision : MonoBehaviour
{
    public Transform teacher;
    public Transform player;
    public Transform lastPlayerPos;
    public bool seesPlayer;
    private RaycastHit hit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerStay(Collider collider)
    {
        //if player is in cone then 
        //shoot a raycast towards player but slightly shorter so it doesn't hit the player if it hits some thing then there is something in the way
        //if it hits player without hitting a wall it is visible, 
        // if it hits wall it is not visible
        if (collider.tag == "Player")
        {
            Vector3 origin = teacher.position;
            Vector3 destination = player.position;
            Vector3 direction = (destination - origin).normalized;

            float distX = Mathf.Abs(teacher.position.x - player.position.x);
            float distZ = Mathf.Abs(teacher.position.z - player.position.z);
            float length = Mathf.Sqrt((distX * distX) + (distZ * distZ)) - 0.75f;

            Ray ray = new Ray(teacher.position, direction);

            Debug.DrawRay(teacher.position, direction * length, Color.red);
            if (Physics.Raycast(ray, length))//if it hits wall
            {

                seesPlayer = false;
            }
            else
            {
                seesPlayer = true;
            }
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            seesPlayer = false;
        }
    }
    void FixedUpdate()
    {
        if (seesPlayer)
        {
            lastPlayerPos.position = player.localPosition;
            teacher.GetComponent<TeacherMovement>().lookAround = false;
            teacher.GetComponent<TeacherMovement>().seePlayer();
        }
    }
}
