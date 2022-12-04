using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    [SerializeField] private Transform[] lootSpots;

    public Transform[] GetLootSpots()
    {
        return lootSpots;
    }
}
