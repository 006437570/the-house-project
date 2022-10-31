using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ContestantAI : MonoBehaviour
{
    //[SerializeField] private float maxHlth;           //THe max health any contestant can have, FUTURE FEATURE
    [SerializeField] private float strtHlth;            //How much health a contestant starts with
    [SerializeField] private float lwHlthThrshld;       //How much health is considered low
    private float currentHealth;

    //[SerializeField] private float influenceRange;      //Range in which contestant will be influenced towards a direct, FUTURE FEATURE

    //Contestant Looting
    [SerializeField] private float lootRange;           //Range in which contestant will loot
    private Transform bestLootSpot;                     //Best loot spot to go to  

    //Contestant combat
    [SerializeField] private float chaseRange;          //Range in which contestant will make chase of enemy player or move tpwards loot
    [SerializeField] private float attackRange;         //Range in which contestant will attack enemy player

    //Contestant movement
    [SerializeField] private Transform contestantTransform;
    [SerializeField] private Loot[] availiableLoot;
    private NavMeshAgent agent;

    //Color changing (TESTING ONLY)
    private Material material;
    //////////////////////////////////

    private Node topNode;

    //Property to keep current health between 0 and the starting health

    public float crntHlth
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, strtHlth); }
    }
    ///////////////////////////////////////////////////////////////////

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();

        //TESTING ONLY
        material = GetComponent<Material>();
        //////////////////////////////////
    }


    private void Start()
    {
        currentHealth = strtHlth;

        
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        //LOOTING BRANCH
        IsThereLootNode lootAvailibleNode = new IsThereLootNode(availiableLoot, contestantTransform, this);
        GoToLootNode gTLootNode = new GoToLootNode(agent, this);
        //RangeNode lootingRngNode = new RangeNode(lootRange, contestantTransform, transform);              //Looting range (may not need)
        LootNode ltNode = new LootNode(agent, this);
        //HealthNode hlthNode = new HealthNode(this, lwHlthThrshld);

        //CHASING BRANCH
        ChaseNode chseNode = new ChaseNode(contestantTransform, agent, this);
        RangeNode chsingRngNode = new RangeNode(chaseRange, contestantTransform, transform);

        //SEQUENCES AND SELECTORS (Very order specfic)
        Sequence chaseSeqeunce = new Sequence(new List<Node> { chsingRngNode, chseNode });
        Sequence goToLootSequence = new Sequence(new List<Node> { lootAvailibleNode, gTLootNode });
        Selector findLoot = new Selector(new List<Node> { goToLootSequence, chaseSeqeunce });
        //Sequence mainLootSequence = new Sequence(new List<Node> { });

        //TOP NODE
        topNode = new Selector(new List<Node> { findLoot, chaseSeqeunce });
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
    
    //Set best loot spot
    public void SetBestLootSpot(Transform bestLootSpot)
    {
        this.bestLootSpot = bestLootSpot;
    }
    
    //Get best loot spot
    public Transform GetBestLootSpot()
    {
        return bestLootSpot;
    }
}
