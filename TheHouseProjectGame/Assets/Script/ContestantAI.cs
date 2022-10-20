using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContestantAI : MonoBehaviour
{
    [SerializeField] private float strtHlth;
    [SerializeField] private float lwHlthThrshld;       //How much health is considered low
    private float crntHlth;

    private void Start()
    {
        crntHlth = strtHlth;
    }

    private void Update()
    {
         
    }

    public float GetCrntHlth()
    {
        return crntHlth;
    }
}
