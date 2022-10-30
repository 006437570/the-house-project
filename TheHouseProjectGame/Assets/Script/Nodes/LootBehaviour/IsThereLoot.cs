using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThereLoot : Node
{
    private Loot[] availibleLoot;   //array of all availible loot to go after
    private Transform target;       //target of loot
    private ContestantAI ai;

    //Constructor
    public IsThereLoot(Loot[] availibleLoot, Transform target, ContestantAI ai)
    {
        this.availibleLoot = availibleLoot;
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform closestLoot = FindClosestLoot(availibleLoot);                              //Find closest loot
        return closestLoot != null ? NodeState.SUCCESS : NodeState.FAILURE;     //If loot is found, return SUCCESS. If not, FAILURE.
    }

    //Calculate the closest loot
    private Transform FindClosestLoot(Loot[] loot)
    {
        Transform clstTarget = null;
        

        return clstTarget;
    }
}
