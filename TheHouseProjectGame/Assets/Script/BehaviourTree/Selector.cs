using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from Node
public class Selector : Node
{
    //Will evaluate list of nodes
    protected List<Node> nodes = new List<Node>();

    //Constructor with the list as parameter
    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    //Interate all nodes and call Evaluate on them
    public override NodeState Evaluate()
    {

        foreach (var node in nodes)
        {
            switch (node.Evaluate())
            {
                case NodeState.RUNNING:             //If any child node is running, set state to RUNNING
                    ndeSte = NodeState.RUNNING;
                    return ndeSte;
                case NodeState.SUCCESS:             //If any child node is success, set state to SUCCESS
                    ndeSte = NodeState.SUCCESS;
                    return ndeSte;
                case NodeState.FAILURE:             //If any child node is failure, continue evulate
                default:
                    break;
            }
        }

        //All child nodes become failure, return failure state
        ndeSte = NodeState.FAILURE;
        return ndeSte;
    }
}
