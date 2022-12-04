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

            if (distance > 0.2f)                                                             //if distance is smaller than a small number, move towards target...
            {
                ai.sprite.color = new Color(1, 1, 0, 1);
                agent.isStopped = false;
                agent.SetDestination(t.position);
            }
            else                                                                            //...otherwise, stop and return SUCCESS
            {
                Debug.Log(distance);
                agent.isStopped = true;
            }
        }

        return distance > 0.2f ? NodeState.RUNNING : NodeState.SUCCESS;
    }
}
