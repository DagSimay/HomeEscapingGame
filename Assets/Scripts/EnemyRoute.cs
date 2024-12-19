
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRoute : MonoBehaviour
{
    public List<Vector3> targets = new List<Vector3>(5);
    private int initialTarget = 0;
    private NavMeshAgent navMeshAgent;
    private bool isWaiting = false;
    private float waitTimer = 0f;
    private float waitingTime = 3f;
    
    void Start()
    {
        targets.Add(new Vector3(0.291000009f,-0.930000007f,0.65200001f));
        targets.Add(new Vector3(0.280999988f,-0.504000008f,-2.32999992f));
        targets.Add(new Vector3(-5.4000001f,-0.694999993f,0.370000005f));
        targets.Add(new Vector3(-4.86000013f,-0.930000007f,-4.96999979f));
        targets.Add(new Vector3(-0.0340000018f,-0.694999993f,-5.04699993f));
        navMeshAgent = GetComponent<NavMeshAgent>();
        moveNextTarget();
    }

    void moveNextTarget()
    { 
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(targets[initialTarget]);
    }
    
    void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && initialTarget != 4)
        {
            navMeshAgent.isStopped = true;
            isWaiting = true;
            if (isWaiting)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer >= waitingTime)
                {
                    isWaiting = false;
                    waitTimer = 0f;
                    initialTarget += 1;
                    moveNextTarget();
                }

                return;
            }
            
        
        }else if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && initialTarget == 4)
        {
            navMeshAgent.isStopped = true;
            isWaiting = true;
            if (isWaiting)
            {
                waitTimer += Time.deltaTime;
                if (waitTimer >= waitingTime)
                {
                    isWaiting = false;
                    waitTimer = 0f;
                    initialTarget = 0;
                    moveNextTarget();
                }
                
                return;
            }
        }
    }
}
