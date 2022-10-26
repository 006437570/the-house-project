using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;   //Need for NavMesgAgent

public class ChaseNode : Node
{

    private Transform target;       //target of chase
    private NavMeshAgent agent;     //Allows contestant to navigate using NavMesh

    //Consturctor
    public ChaseNode(Transform target, NavMeshAgent agent)
    {
        this.target = target;
        this.agent = agent;
    }

    //Abstract, needed for any class making a reference
    public override NodeState Evaluate()
    {
        float distance = Vector2.Distance(target.position, agent.transform.position);   //Calculate distance of target

        if(distance > 0.2f)                                                             //if distance is smaller than a small number, move towards target...
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            return NodeState.RUNNING;
        }
        else                                                                            //...otherwise, stop and return SUCCESS
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
