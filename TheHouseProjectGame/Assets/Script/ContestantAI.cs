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

    //[SerializeField] private float influenceRange;      //Range in which contestant will be influenced towards a direct, FUTURE FEATURE

    //Contestant Looting
    [SerializeField] private float lootRange;           //Range in which contestant will loot
    private Transform bestLootSpot;                     //  

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
    private float crntHlth
    {
        get { return crntHlth; }
        set { crntHlth = Mathf.Clamp(value, 0, strtHlth); }
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
        crntHlth = strtHlth;

        
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {
        IsThereLootNode lootAvailibleNode = new IsThereLootNode(availiableLoot, contestantTransform, this);
        //GoToLootNode goToLootNode = new IsThereLootNode();
    }

    //Grab current health
    public float GetCrntHlth()
    {
        return crntHlth;
    }

    private void Update()
    {
         
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
