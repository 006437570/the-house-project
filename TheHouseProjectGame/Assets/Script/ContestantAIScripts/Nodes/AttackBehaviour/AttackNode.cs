using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackNode : Node
{
    private NavMeshAgent agent;
    private ContestantAI ai;
    private Transform[] target;

    private Vector3 currentVelocity;
    private float smoothDamp;

    public AttackNode(NavMeshAgent agent, ContestantAI ai, Transform[] target)
    {
        this.agent = agent;
        this.ai = ai;
        this.target = target;
        smoothDamp = 1f;
    }

    public override NodeState Evaluate()
    {
        agent.isStopped = true;
        ai.sprite.color = new Color(1, 0, 0, 1);

        foreach (Transform t in target)
        {
            Vector3 direction = t.position - ai.transform.position;
            Vector3 currentDirection = Vector3.SmoothDamp(ai.transform.forward, direction, ref currentVelocity, smoothDamp);
            Quaternion rotation = Quaternion.LookRotation(currentDirection, Vector3.up);
            ai.transform.rotation = rotation;
        }

        return NodeState.RUNNING;

    }

}