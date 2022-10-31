using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthNode : Node
{
    private ContestantAI ai;
    private float threshold;        //Threshold in which is considered low health

    //Constructor
    public HealthNode(ContestantAI ai, float threshold)
    {
        this.ai = ai;
        this.threshold = threshold;
    }

    public override NodeState Evaluate()
    {
        return ai.crntHlth <= threshold ? NodeState.SUCCESS : NodeState.FAILURE;   //if current health is lower than threshold, return SUCCESS. If else, FAILURE.
    }


}
