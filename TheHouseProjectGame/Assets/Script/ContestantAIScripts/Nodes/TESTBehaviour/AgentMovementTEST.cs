using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//THIS SCRIPT IS MEANT TO TEST NAVMESHPLUS
public class AgentMovementTEST : MonoBehaviour
{
    private Vector3 target;     //Target that contestant will move to
    NavMeshAgent agent;         //Agent AI contestant uses to navigate

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;           //RECOMMENDED BY CREATOR TO SET TO FALSE
        agent.updateUpAxis = false;             //RECOMMENDED BY CREATOR TO SET TO FALSE
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
        SetAgentPosition();
    }

    private void SetTargetPosition()
    {
        if(Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);       //make target for contestant to move to on mouse press location
        }
    }

    private void SetAgentPosition()
    {
        agent.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
