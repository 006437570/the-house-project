using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Card : ScriptableObject
{
    
    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDesc;
    public Sprite spriteImage;

    public Card()
    {



    }

    public Card(int Id, string CardName, int Cost, int Power, string CardDesc, Sprite SpriteImage )
    {
        id = Id;
        cardName = CardName;
        cost = Cost;
        power = Power;
        cardDesc = CardDesc;
        spriteImage = SpriteImage; 
    

    }


    



}
