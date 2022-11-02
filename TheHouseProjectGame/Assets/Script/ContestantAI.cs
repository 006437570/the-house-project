using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ContestantAI : MonoBehaviour
{
    private NavMeshAgent agent;

    //Color changing (TESTING ONLY)
    private Material material;
    //////////////////////////////////

    private Node topNode;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        //TESTING ONLY
        material = GetComponent<Material>();
        //////////////////////////////////
    }


    private void Start()
    {
        
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        //TOP NODE
        topNode = new Selector(new List<Node> {  });
    }

    private void Update()
    {
        topNode.Evaluate();

        if (topNode.nodeState == NodeState.FAILURE)
        {
            //TESTING ONLY
            SetColor(Color.red);
            /////////////////////
        }
    }
    //TESTING ONLY
    public void SetColor(Color color)
    {
        material.color = color;
    }
    //////////////////////////////////
}
