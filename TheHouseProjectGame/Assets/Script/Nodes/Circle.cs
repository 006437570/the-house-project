using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    [SerializeField] private Transform circle;

    public Transform GetCircleCenter()
    {
        return circle;
    }
}
