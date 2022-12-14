using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherLootSpotsNode : Node
{
    private Loot[] availableLoot;               //Loot spots in an array
    private Transform contestant;               //Contestant's location
    private ContestantAI ai;                    //Contestant's AI

    //CONSTRUCTOR
    public GatherLootSpotsNode(Loot[] availableLoot, Transform contestant, ContestantAI ai)
    {
        this.availableLoot = availableLoot;
        this.contestant = contestant;
        this.ai = ai;
    }

    public override NodeState Evaluate()
    {
        Transform closestSpot = FindClosestSpot();                              //Find closest loot spot
        ai.SetClosestSpot(closestSpot);                                         //Once found, set closest loot spot
        
        if(closestSpot == null)
        {
            Debug.Log("Could not find the closest spot!");
        }

        return closestSpot != null ? NodeState.SUCCESS : NodeState.FAILURE;     //If one is found, SUCCESS. If not, FAILURE.
    }

    private Transform FindClosestSpot()
    {
        /*Check if there already is closest spot
        if (ai.GetClosestLootSpot() != null)
        {
            return ai.GetClosestLootSpot();
        }
        */////
        
        Transform closestSpot = null;
        foreach(Loot aL in availableLoot)
        {
            Transform bestLootAvailable = FindBestLootAvailable(aL);
            if (bestLootAvailable != null)
            {
                closestSpot = bestLootAvailable;
            }
        }

        return closestSpot;
    }

    private Transform FindBestLootAvailable(Loot cS)
    {
        Transform[] availableSpots = cS.GetLootSpots();                     //Gather all loot spots
        Transform bestSpot = null;
        float closestDistSqrd = Mathf.Infinity;                             //Take closest range, which is infinity
        //Vector3 currentPos = ai.transform.position;

        foreach(Transform aS in availableSpots)
        {
            if (aS)                                                         //If there is an availible spot
            {
                Vector3 dirToSpot = contestant.position - aS.position;


                float distSqrdToSpot = dirToSpot.sqrMagnitude;
                if (distSqrdToSpot < closestDistSqrd)
                {
                    closestDistSqrd = distSqrdToSpot;
                    bestSpot = aS;
                }
            }
        }

        return bestSpot;

    }
}
