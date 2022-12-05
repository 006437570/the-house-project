using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeNode : Node
{
    private float range;            //Range in which to do anything
    private Transform target;       //Target of range
    private Transform origin;       //Transform from which calculates the distance

    //Constructor
    public RangeNode(float range, Transform target, Transform origin)
    {
        this.range = range;
        this.target = target;
        this.origin = origin;
    }

    //Abstract, needed for any class making a reference
    public override NodeState Evaluate()
    {
        float distance = Vector2.Distance(target.position, origin.position);        //Calculate distance between player and distance
        return distance <= range ? NodeState.SUCCESS : NodeState.FAILURE;           //If in range, return SUCCESS. If else, FAILURE
    }
}
