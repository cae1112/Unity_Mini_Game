using UnityEngine;
using UnityEngine.AI;

public class NPSFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform playerTransform;
    private NavMeshAgent agent;
    void Start()
    {
      agent = GetComponent<NavMeshAgent>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }
    }
}
