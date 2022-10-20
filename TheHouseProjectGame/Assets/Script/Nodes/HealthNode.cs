using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node
{
    private ContestantAI ai;
    private float threshold;

    //Constructor
    public HealthNode(ContestantAI ai, float threshold)
    {
        this.ai = ai;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        //Return current health if lower than threshold, otherwise return failure
        return ai.GetCrntHlth() <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }


}
