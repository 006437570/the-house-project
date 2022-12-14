using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public string cardDesc;
    public Sprite spriteImage;

    public Text nameText;
    public Text costText;
    public Text powerText;
    public Text descText;
    public Image artImage;
    
    public bool cardBack;
    public static bool staticCardBack;

    public GameObject Hand;
    public int numberOfCardsInDeck;
    void Start()
    {
        numberOfCardsInDeck = PlayerDeck.deckSize;
        displayCard[0] = CardDatabase.cardList[displayId];
    }

    // Update is called once per frame
    void Update()
    {
        id = displayCard[0].id;
        cardName = displayCard[0].cardName;
        cost = displayCard[0].cost;
        power = displayCard[0].power;
        cardDesc = displayCard[0].cardDesc;
        spriteImage = displayCard[0].spriteImage;

        nameText.text = " " + cardName;
        costText.text = " " + cost;
        powerText.text = " " + power;
        descText.text = " " + cardDesc;
        artImage.sprite = spriteImage;
    }
}
