using UnityEngine;

[System.Serializable]
public class CardController
{
    private Deck deck;
    private CardHand hand;

    public void Initialize(PlayerController player)
    {
        deck = new Deck_Basic();
        deck.Initialize();
        hand = new CardHand(player, deck);

        Managers.UI.Initialize(hand, deck);
    }

    public bool UseCard(bool leftHand)
    {
        bool used = leftHand ? hand.UseLeftCard() : hand.UseRightCard();
        if (used) Managers.UI.UpdateCardUI();
        return used;
    }

    public CardHand GetHand() => hand;
}
