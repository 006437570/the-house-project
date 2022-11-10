using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ContestantAI : MonoBehaviour
{
    //Movement
    private NavMeshAgent agent;
    [SerializeField] private Transform contestantTransform;

    //Circle related
    [SerializeField] private Collider2D Circle;

    //Loot related
    [SerializeField] private Loot[] availibleLoot;
    private Transform closestSpot;

    //Sprite
    public SpriteRenderer sprite;

    private Node topNode;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sprite = GetComponent<SpriteRenderer>();
        agent.updateRotation = false;           //RECOMMENDED BY CREATOR TO SET TO FALSE
        agent.updateUpAxis = false;             //RECOMMENDED BY CREATOR TO SET TO FALSE

    }


    private void Start()
    {
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {

        //LOOT LEAVES
        GatherLootSpotsNode gLsNode = new GatherLootSpotsNode(availibleLoot, contestantTransform, this);
        GoToLoot GtLNode = new GoToLoot(agent, this);

        //RING LEAVES
        IfOutsideRingNode IoRNode = new IfOutsideRingNode(this, Circle);

        //BRANCES
        Sequence RfRSequence = new Sequence(new List<Node> { IoRNode });
        Sequence gLsSequence = new Sequence(new List<Node> { gLsNode, GtLNode });

        //TOP NODE
        topNode = new Selector(new List<Node> { RfRSequence, gLsSequence });
    }

    private void Update()
    {
        topNode.Evaluate();

        if (topNode.nodeState == NodeState.FAILURE)
        {
            sprite.color = new Color(1,0,0,1);
            agent.isStopped = true;
        }
    }

    //Setter and Getter for Loot
    public void SetClosestSpot(Transform closestSpot)
    {
        this.closestSpot = closestSpot;
    }

    public Transform GetClosestLootSpot()
    {
        return closestSpot;
    }
}
