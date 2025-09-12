using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.Rendering.GPUSort;

public class CardHand
{
    private Card leftCard;
    private Card rightCard;
    private Deck deck;
    private CardUsing_Interface owner;
    public Card LeftPendingCard; // 보류 중인 카드
    public Card RightpendingCard; // 보류 중인 카드
    public Card GetLeftCard() => leftCard;
    public Card GetRightCard() => rightCard;

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
        {
            leftCard = deck.DrawCard();
        
            //Debug.Log("leftCard Draw");
          
        }
        ;

        if (rightCard == null)
        {
            rightCard = deck.DrawCard();
           // Debug.Log("Right Card Draw");
        }
    }
    public bool UseLeftCard()
    {
       
        if (leftCard == null || owner == null)
             return false;

        
        LeftPendingCard = leftCard;
        if (!leftCard.Using_Card(owner))
        {
            LeftPendingCard = null;// 모션 트리거만
            return false;
        }
        return true;
    }
    public bool UseRightCard()
    {
        if (rightCard == null || owner == null) return false;

        RightpendingCard = rightCard;
        if (!rightCard.Using_Card(owner))
        {
            RightpendingCard = null;
            return false;
        }
        return true;
    }

    public void ConsumePendingCard()
    {
        if (LeftPendingCard != null)
        {
            deck.AddTomb(LeftPendingCard);
            LeftPendingCard = null;
            leftCard = null; // 실제로 손에서 제거
            RefreshHand();
        }
        if (RightpendingCard != null)
        {
            deck.AddTomb(RightpendingCard);
            RightpendingCard = null;
            rightCard = null; 
            RefreshHand();
        }
    }
}
