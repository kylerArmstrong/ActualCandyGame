using UnityEngine;

public class StudentMovement : MonoBehaviour
{
    public Transform player;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    public string mode;
    public Transform[] desks;
    public int increment;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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
        navMeshAgent.SetDestination(desks[increment].position);
    }

    public void nextClass()//will be called by schedule or something
    {
        increment++;
    }

}
