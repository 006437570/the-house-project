using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNode : Node
{
    private float range;            //Range in which to do anything
    private float distance;         //Distance from target
    private Transform[] target;     //Target of range
    private Transform origin;       //Transform from which calculates the distance

    //Constructor
    public RangeNode(float range, Transform[] target, Transform origin)
    {
        this.range = range;
        this.target = target;
        this.origin = origin;
    }

    //Abstract, needed for any class making a reference
    public override NodeState Evaluate()
    {

        foreach (Transform t in target)
        {
            if (t == null)
            {
                return NodeState.FAILURE;
            }

            distance = Vector2.Distance(t.position, origin.position);        //Calculate distance between player and distance

        }

        return distance <= range ? NodeState.SUCCESS : NodeState.FAILURE;           //If in range, return SUCCESS. If else, FAILURE
    }
}
