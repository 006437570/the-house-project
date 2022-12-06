using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //Need for NavMesgAgent

public class ChaseNode : Node
{

    private Transform[] target;     //target of chase
    private float distance;         //Distance from target
    private NavMeshAgent agent;     //Allows contestant to navigate using NavMesh
    private ContestantAI ai;

    //Consturctor
    public ChaseNode(Transform[] target, NavMeshAgent agent, ContestantAI ai)
    {
        this.target = target;
        this.agent = agent;
        this.ai = ai;
    }

    //Abstract, needed for any class making a reference
    public override NodeState Evaluate()
    {
        foreach (Transform t in target)
        {
            distance = Vector2.Distance(t.position, agent.transform.position);   //Calculate distance of target

            if (distance > 1f)                                                             
            {
                ai.sprite.color = new Color(1, 1, 0, 1);
                agent.isStopped = false;
                agent.SetDestination(t.position);
            }
            else                                                                            
            {
                ai.sprite.color = new Color(1, 1, 1, 1);
                agent.isStopped = true;
            }
        }

        return distance > 1f ? NodeState.RUNNING : NodeState.SUCCESS;                       //if distance is smaller than a small number, move towards target. Otherwise, stop and return SUCCESS
    }
}
