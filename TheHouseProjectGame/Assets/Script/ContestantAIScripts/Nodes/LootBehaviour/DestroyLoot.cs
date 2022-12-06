using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLoot : MonoBehaviour
{

    //TEST: Destroy Loot
    private void OnMouseDown()
    {
        Debug.Log("Click!");
        Destroy(gameObject);
    }
}
