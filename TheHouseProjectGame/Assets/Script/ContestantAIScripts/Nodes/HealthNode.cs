using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node
{
    private ContestantAI ai;
    private float threshold;

    public HealthNode(ContestantAI ai, float threshold)
    {
        this.ai = ai;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        //Return SUCCESFUL if under threshold, otherwise FAILURE
        return ai.currentHealth <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}