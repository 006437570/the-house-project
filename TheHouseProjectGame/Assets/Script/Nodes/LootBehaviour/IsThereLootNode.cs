using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsThereLootNode : Node
{
    private Loot[] availibleLoot;   //array of all availible loot to go after
    private Transform target;       //target of loot
    private ContestantAI ai;

    //Constructor
    public IsThereLootNode(Loot[] availibleLoot, Transform target, ContestantAI ai)
    {
        this.availibleLoot = availibleLoot;
        this.target = target;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform closestLootLoc = FindClosestLootLoc();                              //Find closest loot location
        ai.SetBestLootSpot(closestLootLoc); ;
        return closestLootLoc != null ? NodeState.SUCCESS : NodeState.FAILURE;        //If loot is found, return SUCCESS. If not, FAILURE.
    }

    //Calculate the closest loot location
    private Transform FindClosestLootLoc()
    {
        Transform clstTarget = null;
        for(int i = 0; i < availibleLoot.Length; i++)
        {
            Transform bestLootSpot = FindClosestLootSpot(availibleLoot[i]);
            if(bestLootSpot != null)
            {
                clstTarget = bestLootSpot;
            }
        }

        return clstTarget;
    }

    //Calculate the closest loot spot
    private Transform FindClosestLootSpot(Loot loot)
    {
        Transform[] availibleLootSpots = loot.GetLootSpots();                                   //Get current availble loot spots
        Transform clstLoot = null;
        float clstLootSqrd = Mathf.Infinity;                                                    //Closest distance squared to loot
        for(int i = 0; i < availibleLoot.Length; i++)
        {
            Debug.Log(availibleLoot[i]);
            Vector2 dirToLoot = ai.transform.position - availibleLootSpots[i].position;         //Direction of loot
            float distSqrToLoot = dirToLoot.sqrMagnitude;                                       //Distance squared to loot

            if (distSqrToLoot < clstLootSqrd)                                                   //Set closest distance and closest spot as closest
            {
                clstLootSqrd = distSqrToLoot;
                clstLoot = availibleLootSpots[i];
            }
        }

        return clstLoot;

    }
}
