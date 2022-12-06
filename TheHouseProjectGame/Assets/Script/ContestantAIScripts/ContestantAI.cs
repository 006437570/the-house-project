using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ContestantAI : MonoBehaviour
{

    //Health
    [SerializeField] private float maxHealth;
    [SerializeField] private float startingHealth;
    [SerializeField] private float lowHealthThreshold;
    //[SerializeField] private float healthRestoreRate;

    private float cH;

    //Clamp to keep health from going past startingHealth
    public float currentHealth
    {
        get { return cH; }
        set { cH = Mathf.Clamp(value, 0, maxHealth); }
    }

    //Movement
    private NavMeshAgent agent;
    [SerializeField] private Transform contestantTransform;
    [SerializeField] Transform[] enemyTransform;
    [SerializeField] private float chaseRange;
    [SerializeField] private float attackRange;

    //Combat
    public float attackDmg;

    //Circle related
    // [SerializeField] private Collider2D Circle;

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
        cH = startingHealth;
        ConstructBehaviourTree();
    }

    private void ConstructBehaviourTree()
    {

        //RANGE-CHASE
        ChaseNode chaseNode = new ChaseNode(enemyTransform, agent, this);
        RangeNode chaseRangeNode = new RangeNode(chaseRange, enemyTransform, transform);
        RangeNode attackRangeNode = new RangeNode(attackRange, enemyTransform, transform);

        //ATTACK
        AttackNode attackNode = new AttackNode(agent, this, contestantTransform, enemyTransform);

        //FLEE
        HealthNode healthNode = new HealthNode(this, lowHealthThreshold);

        //LOOT
        GatherLootSpotsNode gLsNode = new GatherLootSpotsNode(availibleLoot, contestantTransform, this);
        GoToLoot GtLNode = new GoToLoot(agent, this);

        //BRANCES
        Sequence chaseSequence = new Sequence(new List<Node> { chaseRangeNode, chaseNode });
        Sequence attackSequence = new Sequence(new List<Node> { attackRangeNode, attackNode });

        Sequence lootSequence = new Sequence(new List<Node> { gLsNode, GtLNode });

        //TOP NODE
        topNode = new Selector(new List<Node> { attackSequence, chaseSequence, lootSequence });
    }

    private void Update()
    {
        topNode.Evaluate();

        if(currentHealth <= 0)
        {
            Death();
        }

        if (topNode.nodeState == NodeState.FAILURE)
        {
            Debug.Log("Top Node FAILURE");
            sprite.color = new Color(0,0,0,1);
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
    ///////////////////////////////
    

    //Give loot to player
    public void LootBuff(float buff)
    {
        currentHealth += buff;
        attackRange += buff;
    }

    //TEST: Danaged clicked contestant
    private void OnMouseDown()
    {
        Debug.Log("Click!"); 
        float dmg = 1;
        TakeDamage(dmg);
    }

    //Take damage
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
    }

    public void Death()
    {
        Destroy(gameObject);
    }
}
