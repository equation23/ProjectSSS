using UnityEngine;
using UnityEngine.UI;

public class UI_Card : UI_Base
{
    public Image cardImage;

    public Card CurrentCard { get; private set; }

    public void SetCard(Card card)
    {
        CurrentCard = card;

        if (card == null || card.GetData() == null)
        {
            cardImage.sprite = null;
            return;
        }

    }
    public void SetCardAndSprite(Card card)
    {
        CurrentCard = card;

        if (card == null || card.GetData() == null)
        {
            cardImage.sprite = null;
            return;
        }
        SetCardSprite();
    }
    public void SetCardSprite()
    {
        cardImage.sprite = CurrentCard.GetData().cardSprite;
    }
    public Card GetCard()
    {
        return CurrentCard;
    }
}