using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //Need for NavMesgAgent

public class LootNode : Node
{
    private NavMeshAgent agent; //Allows contestant to navigate using NavMesh
    private ContestantAI ai;

    public LootNode(NavMeshAgent agent, ContestantAI ai)
    {
        this.agent = agent;
        this.ai = ai;
    }

    public override NodeState Evaluate()    //For now, turn blue and stop moving
    {
        agent.isStopped = true;
        ai.SetColor(Color.blue);
        return NodeState.RUNNING;
    }
}
