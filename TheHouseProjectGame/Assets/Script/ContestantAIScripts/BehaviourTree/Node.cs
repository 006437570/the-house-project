using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//hello!8=====D
[System.Serializable]
public abstract class Node
{
    protected NodeState ndeSte;

    //Geter for ndeSte variable
    public NodeState nodeState {get{return ndeSte;}}

    //Returns type nodeState
    public abstract NodeState Evaluate();
}

//Describes state of node
public enum NodeState
{
    RUNNING, SUCCESS, FAILURE
}