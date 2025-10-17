using UnityEngine;

public class StudentMovement : MonoBehaviour
{
    public Transform player;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public string mode;
    public Transform[] desks;
    public Transform[] spots;
    public int period;
    public int increment;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //setDeal("girls bathroom");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Invoke(mode, 0f);
    }
    public void hold()
    {
        //does nothiing
    }

    public void learn()
    {
        navMeshAgent.SetDestination(desks[period].position);
    }

    public void nextClass()//will be called by schedule or something
    {
        period++;
    }

    public void deal()
    {
        navMeshAgent.SetDestination(spots[increment].position);
    }

    public void setDeal(string loc)
    {
        mode = "deal";
        if(loc == "boys bathroom")
        {
            increment = 0;
        }
        else if(loc == "girls bathroom")
        {
            increment = 1;
        }
    }

}
