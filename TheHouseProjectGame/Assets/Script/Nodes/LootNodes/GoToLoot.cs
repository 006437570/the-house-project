using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoToLoot : Node
{
    private NavMeshAgent agent;     //Allows contestant to navigate using NavMesh
    private ContestantAI ai;

    //Consturctor
    public GoToLoot(NavMeshAgent agent, ContestantAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    //Abstract, needed for any class making a reference
    public override NodeState Evaluate()
    {

        Transform lootSpot = ai.GetClosestLootSpot();                                      //Calculate distance of target

        if (lootSpot == null)                                                             //if there is no loot spot, set to FAILURE
        {
            Debug.Log("Could Not Find a Loot Spot!");
            return NodeState.FAILURE;
        }

        float distance = Vector3.Distance(lootSpot.position, agent.transform.position);

        if(distance > 0.2f)                                 //if distance is greater than some really small number, set to RUNNING
        {
            ai.sprite.color = new Color(1, 1, 0, 1);
            agent.isStopped = false;
            agent.SetDestination(lootSpot.position);
            return NodeState.RUNNING;
        }
        else
        {
                                                            //If otherwise, return SUCCESS
        }
        {
            ai.sprite.color = new Color(0, 0, 1, 1);
            agent.isStopped = true;
            return NodeState.SUCCESS;
        }
    }
}
