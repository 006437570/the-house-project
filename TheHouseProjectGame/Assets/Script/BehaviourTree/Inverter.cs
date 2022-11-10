using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from Node
//Inverts conditions when needed
public class Inverter : Node
{
    //Will evaluate list of nodes
    protected Node node;

    //Constructor with the list as parameter
    public Inverter(Node node)
    {
        this.node = node;
    }

    //Interate all nodes and call Evaluate on them
    public override NodeState Evaluate()
    {

            switch (node.Evaluate())
            {
                case NodeState.RUNNING:             //If any child node is running
                ndeSte = NodeState.RUNNING;
                    break;
                case NodeState.SUCCESS:             //If any child node is successful, set state to FAILURE
                ndeSte = NodeState.FAILURE;
                    break;
                case NodeState.FAILURE:             //If any child is failure, set state to SUCCESS
                    break;
                default:
                    break;
            }
        return ndeSte;
    }
}
