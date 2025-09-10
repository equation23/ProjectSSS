using System.Xml.Linq;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class CardHand
{
    private Card leftCard;
    private Card rightCard;
    private Deck deck;
    private CardUsing_Interface owner;
    public Card LeftPendingCard; // 보류 중인 카드
    public Card RightpendingCard; // 보류 중인 카드


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
            leftCard = deck.DrawCard();
       
        if (rightCard == null)
            rightCard = deck.DrawCard();
    }
    public bool UseLeftCard()
    {
       
        if (leftCard == null || owner == null)
             return false;


        LeftPendingCard = leftCard;
        leftCard.Using_Card(owner); // 모션 트리거만
        return true;
    }
    public bool UseRightCard()
    {
        if (rightCard == null || owner == null) return false;

        RightpendingCard = rightCard;
        rightCard.Using_Card(owner);
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
