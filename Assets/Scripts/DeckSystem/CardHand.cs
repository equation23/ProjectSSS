using System.Xml.Linq;
using UnityEngine;

public class CardHand
{
    private Card leftCard;
    private Card rightCard;
    private Deck deck;
    private CardUsing_Interface owner;



    public CardHand(CardUsing_Interface owner, Deck deck)
    {
        this.owner = owner;
        this.deck = deck;

        leftCard = deck.DrawCard();
        rightCard = deck.DrawCard();
    }
    public void Initialize()
    {

    }
    public void RefreshHand()
    {
        if (deck == null) return;
        if (leftCard == null)
            { leftCard = deck.DrawCard();
            Debug.Log("Successful Draw LeftCard");  
        }
        if (rightCard == null)
            rightCard = deck.DrawCard();
    }
    public bool UseLeftCard()
    {
       
        if (leftCard == null )
        {
            Debug.Log("Fail No LeftCard");
            return false;
        
        }
        if( owner == null)
        {
            Debug.Log("Fail No Owner");
            return false;
        }

        Debug.Log("Success Use Card");
        leftCard.Using_Card(owner);
        deck.AddTomb(leftCard);
        leftCard = null;

        int Cards = deck.Count();
        Debug.Log(Cards);
        return true;
    }
    public bool UseRightCard()
    {
        if (rightCard == null || owner == null) return false;
        rightCard.Using_Card(owner);
        deck.AddTomb(rightCard);
        rightCard = null;

        return true;
    }
}
