using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContestantAI : MonoBehaviour
{
    //[SerializeField] private float maxHlth;           //THe max health any contestant can have, FUTURE FEATURE
    [SerializeField] private float strtHlth;            //How much health a contestant starts with
    [SerializeField] private float lwHlthThrshld;       //How much health is considered low

    //[SerializeField] private float influenceRange;      //Range in which contestant will be influenced towards a direct, FUTURE FEATURE

    //Contestant Looting
    [SerializeField] private float lootRange;           //Range in whicb contestant will loot

    //Contestant combat
    [SerializeField] private float chaseRange;          //Range in which contestant will make chase of enemy player or move tpwards loot
    [SerializeField] private float attackRange;         //Range in which contestant will attack enemy player

    //Contestant movement
    [SerializeField] private Transform contestantTransform;

    //Property to keep current health between 0 and the starting health
    private float crntHlth
    {
        get { return crntHlth; }
        set { crntHlth = Mathf.Clamp(value, 0, strtHlth); }
    }
    ///////////////////////////////////////////////////////////////////

    private void Start()
    {
        crntHlth = strtHlth;
    }

    private void Update()
    {
         
    }

    //Grab current health
    public float GetCrntHlth()
    {
        return crntHlth;
    }
}
