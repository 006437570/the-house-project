using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //Need for NavMesgAgent

//Similar to ChaseNode
public class GoToLootNode : Node
{
    private NavMeshAgent agent;     //Allows contestant to navigate using NavMesh

    //TESTING ONLY
    private ContestantAI ai;
    //////////////////////////////////

    //Consturctor
    public GoToLootNode(NavMeshAgent agent, ContestantAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    //Abstract, needed for any class making a reference
    public override NodeState Evaluate()
    {
        Transform loot = ai.GetBestLootSpot();                                          //Get vest loot location for contestant
        if(loot == null)
        {
            return NodeState.FAILURE;
        }

        //TESTING ONLY
        ai.SetColor(Color.blue);
        //////////////////////////////////

        float distance = Vector2.Distance(loot.position, agent.transform.position);      //Calculate distance of loot

        if (distance > 0.2f)                                                             //if distance is smaller than a small number, move towards loot...
        {
            agent.isStopped = false;
            agent.SetDestination(loot.position);
            return NodeState.RUNNING;
        }
        else                                                                            //...otherwise, stop and return SUCCESS
        {
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
