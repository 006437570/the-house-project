using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    //internal Vector2 position;
    [SerializeField] private Transform[] lootSpots;  //Spots within loot locations to loot

    public Transform[] GetLootSpots()   //return loot spots
    {
        return lootSpots;
    }


}
