using UnityEngine;
using UnityEngine.AI;

public class TeacherMovement : MonoBehaviour
{
    public Transform player;
    public Transform teachTarget;
    public Transform wanderTarget;
    public Transform deskTarget;
    private NavMeshAgent navMeshAgent;
    public string mode;
    public string teachMode;
    public Transform[] patrolPath;
    public int increment;
    public float waiting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke(mode, 0f);
    }

    public void chase()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    public void teach()
    {
        if (player != null)
        {
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
    }

    public void hold()
    {
        //do nothing
    }

    public void patrol()//patrol hallways
    {
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

    public bool close()
    {
        if (waiting > 0)
        {
            return false;
        }
        float maxDeviation = 0.2f;
        //if ((this.transform.position.x - maxDeviation < patrolPath[increment].position.x || this.transform.position.x + maxDeviation > patrolPath[increment].position.x) && (this.transform.position.z - maxDeviation < patrolPath[increment].position.z || this.transform.position.z + maxDeviation < patrolPath[increment].position.z))
        if(Mathf.Abs(this.transform.position.x) - Mathf.Abs(patrolPath[increment].position.x) < maxDeviation && Mathf.Abs(this.transform.position.z) - Mathf.Abs(patrolPath[increment].position.z) < maxDeviation && Mathf.Abs(this.transform.position.x) - Mathf.Abs(patrolPath[increment].position.x) > -1*maxDeviation && Mathf.Abs(this.transform.position.z) - Mathf.Abs(patrolPath[increment].position.z) > -1*maxDeviation)
        {
            waiting = 2;
            Debug.Log("close");
            return true;
        }
        return false;
    }
}
