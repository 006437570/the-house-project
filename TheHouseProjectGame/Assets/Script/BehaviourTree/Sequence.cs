using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inherits from Node
public class Sequence : Node
{
    //Will evaluate list of nodes
    protected List<Node> nodes = new List<Node>();

    //Constructor with the list as parameter
    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }

    //Interate all nodes and call Evaluate on them
    public override NodeState Evaluate()
    {
        bool isAnyNodeRunning = false;

        foreach(var node in nodes)
        {
            switch(node.Evaluate())
            {
                case NodeState.RUNNING:             //If any child node is running
                    isAnyNodeRunning = true;
                    break;
                case NodeState.SUCCESS:             //If any child node is successful, continue evaluate child nodes
                    break;
                case NodeState.FAILURE:
                    ndeSte = NodeState.FAILURE;     //If any child node is failure, entire sequence fails
                    return ndeSte;
                default:
                    break;
            }
        }

        //Is any child running? Y - Set to RUNNING, N - All child nodes are success
        ndeSte = isAnyNodeRunning ? NodeState.RUNNING : NodeState.SUCCESS;
        return ndeSte;
    }
}
