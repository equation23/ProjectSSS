using UnityEngine;

public class UI_Hand : UI_Base
{
    public UI_Card leftSlot;
    public UI_Card rightSlot;
    private CardHand hand;


    public CardHand GetHand() { return hand; }
    public void Initialize(CardHand cardHand)
    {
        hand = cardHand;
        Refresh();
        leftSlot.SetCardSprite();
        rightSlot.SetCardSprite();

    }

    public void Refresh()
    {
        if (hand == null) return;

        leftSlot.SetCard(hand.GetLeftCard());
        rightSlot.SetCard(hand.GetRightCard());
    }
}