using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public static List <Card> cardList = new List<Card>();

    void Awake()
    {
        cardList.Add(new Card(0, "None", 0 , 0, "None", Resources.Load<Sprite>("Test") ));
        cardList.Add(new Card(1, "Tornado", 2, 2, "WIND!", Resources.Load<Sprite>("Tornado") ));
        cardList.Add(new Card(2, "Lava", 2, 2, "HOT", Resources.Load<Sprite>("Lava") ));
        cardList.Add(new Card(3, "Blizzard", 2, 2, "COLD WIND", Resources.Load<Sprite>("Blizzard") ));
        cardList.Add(new Card(4, "EMP", 2, 2, "NO POWER", Resources.Load<Sprite>("EMP") ));
    }
}
