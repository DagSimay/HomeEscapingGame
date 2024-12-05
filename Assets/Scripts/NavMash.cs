
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMash : MonoBehaviour
{

    
    public List<Transform> targets = new List<Transform>(5);
    public int initialTarget = 0;
    private NavMeshAgent navMeshAgent;
    
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveNextTarget();
    }

    void moveNextTarget()
    {
        
       navMeshAgent.SetDestination(targets[initialTarget].position);
    }
    
    void Update()
    {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && initialTarget != 4)
            {
                
                initialTarget += 1;
                moveNextTarget();
            
            }else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && initialTarget == 4)
            {
                
                initialTarget = 0;
                moveNextTarget();
            }
          
    }
}
