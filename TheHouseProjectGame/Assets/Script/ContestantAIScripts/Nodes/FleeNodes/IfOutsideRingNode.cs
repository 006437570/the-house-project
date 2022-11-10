using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IfOutsideRingNode : Node
{
    private ContestantAI ai;
    private Collider2D Ring;

    private bool hasLeftRing = false;

    public IfOutsideRingNode(ContestantAI ai, Collider2D Ring)
    {
        this.ai = ai;
        this.Ring = Ring;
    }

    public override NodeState Evaluate()
    {
        if (hasLeftRing)
        {
            return NodeState.RUNNING;
        }

        ai.sprite.color = new Color(0, 0, 1, 1);
        return NodeState.SUCCESS;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        { 
            Debug.Log("Player is inside the Ring!");
            hasLeftRing = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Circle")
        {
            Debug.Log("Player is outside the Ring!");
            hasLeftRing = true;
        }
    }
}
