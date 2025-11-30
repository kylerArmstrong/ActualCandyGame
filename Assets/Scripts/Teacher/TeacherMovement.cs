using UnityEngine;
using UnityEngine.AI;

public class TeacherMovement : MonoBehaviour
{
    public Transform lastPlayerPos;
    public Transform lookAroundTarget;
    public Transform teachTarget;
    public Transform wanderTarget;
    public Transform deskTarget;
    private NavMeshAgent navMeshAgent;
    public string mode;
    public string teachMode;
    public Transform[] patrolPath;
    public int increment;
    public float waiting;
    public bool lookAround;
    public float lookingTimer;

    public int patrolPeriod;
    public GameObject schedule;
    public bool patrolled;

    public GameObject player;
    public GameObject sentHome;

    public GameObject bEars;
    public GameObject rEars;
    public GameObject yEars;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lookAround = false;
        lookingTimer = 10f;
        teachMode = "teach";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(schedule.GetComponent<Schedule>().inc == patrolPeriod-1 && !patrolled)
        {
            mode = "patrol";
            patrolled = true;
        }
        else if(schedule.GetComponent<Schedule>().inc != patrolPeriod - 1)
        {
            mode = "teach";
        }
        Invoke(mode, 0f);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            catchPlayer();
        }
    }

    public void catchPlayer()
    {
        player.GetComponent<PlayerProperties>().money = player.GetComponent<PlayerProperties>().money * .75f;
        sentHome.SetActive(true);
    }

    public void chase()
    {
        if (lastPlayerPos != null)
        {
            if (closeChase())
            {
                //look around 
                //basically just wander in a small area and rotate in random direction to look around
                lookAround = true;
                //this.transform.localEulerAngles = new Vector3(0, Random.Range(0, 360), 0); 
            }
            if (lookAround)
            {
                rEars.SetActive(false);
                bEars.SetActive(false);
                yEars.SetActive(true);
                navMeshAgent.SetDestination(lookAroundTarget.position);
            }
            else if (!lookAround)//actually chasing player
            {
                rEars.SetActive(true);
                bEars.SetActive(false);
                yEars.SetActive(false);
                navMeshAgent.SetDestination(lastPlayerPos.position);
                lookingTimer = 10f;
            }
            if (lookingTimer < 0)
            {
                lookAround = false;
                mode = "patrol";
                //teachMode = "teach";
            }
            lookingTimer -= Time.deltaTime;
        }
    }

    public void teach()
    {
        rEars.SetActive(false);
        bEars.SetActive(true);
        yEars.SetActive(false);
        if (teachMode == "teach")//teaching area
        {
            navMeshAgent.SetDestination(teachTarget.position);
        }
        else if (teachMode == "wander")//wander class
        {
            navMeshAgent.SetDestination(wanderTarget.position);
        }
        else if (teachMode == "desk")//sit at desk
        {
            navMeshAgent.SetDestination(deskTarget.position);
        }
    }

    public void hold()
    {
        //do nothing
    }

    public void patrol()//patrol hallways
    {
        rEars.SetActive(false);
        bEars.SetActive(false);
        yEars.SetActive(true);
        //go to target
        //if target is reached 
        //increment++
        //if increment > 13
        //increment = 0
        waiting -= Time.deltaTime;
        navMeshAgent.SetDestination(patrolPath[increment].position);
        if (close())
        {
            increment++;
        }
        //Debug.Log((this.transform.position.x == patrolPath[increment].position.x) + " " + (this.transform.position.z == patrolPath[increment].position.z));
        if (increment > 13)
        {
            increment = 0;
        }
    }

    public void seePlayer()
    {
        if(mode == "patrol")
        {
            mode = "chase";
        }
    }

    public bool close()
    {
        if (waiting > 0)
        {
            return false;
        }
        float maxDeviation = 0.2f;
        //if ((this.transform.position.x - maxDeviation < patrolPath[increment].position.x || this.transform.position.x + maxDeviation > patrolPath[increment].position.x) && (this.transform.position.z - maxDeviation < patrolPath[increment].position.z || this.transform.position.z + maxDeviation < patrolPath[increment].position.z))
        if (Mathf.Abs(this.transform.position.x) - Mathf.Abs(patrolPath[increment].position.x) < maxDeviation && Mathf.Abs(this.transform.position.z) - Mathf.Abs(patrolPath[increment].position.z) < maxDeviation && Mathf.Abs(this.transform.position.x) - Mathf.Abs(patrolPath[increment].position.x) > -1 * maxDeviation && Mathf.Abs(this.transform.position.z) - Mathf.Abs(patrolPath[increment].position.z) > -1 * maxDeviation)
        {
            waiting = 2;
            return true;
        }
        return false;
    }

    public bool closeChase()
    {
        float maxDeviation = 0.2f;
        if (Mathf.Abs(this.transform.position.x) - Mathf.Abs(lastPlayerPos.position.x) < maxDeviation && Mathf.Abs(this.transform.position.z) - Mathf.Abs(lastPlayerPos.position.z) < maxDeviation && Mathf.Abs(this.transform.position.x) - Mathf.Abs(lastPlayerPos.position.x) > -1 * maxDeviation && Mathf.Abs(this.transform.position.z) - Mathf.Abs(lastPlayerPos.position.z) > -1 * maxDeviation)
        {
            return true;
        }
        return false;
    }
}
