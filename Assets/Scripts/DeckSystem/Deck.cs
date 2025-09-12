using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private List<Card> cards = new List<Card>();
    private List<Card> tomb = new List<Card>();

    virtual public void Initialize() { }
    // 덱에 카드 추가
    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    // 덱에서 카드 뽑기
    public Card DrawCard()
    {
        if (cards.Count == 0) return null;
        Card c = cards[0];
        cards.RemoveAt(0); // 맨 앞 제거
        return c;
    }


    // 덱에 몇 장 남았는지 확인
    public int Count()
    {
        return cards.Count;
    }

    public void AddTomb(Card card)
    {
        tomb.Add(card);
    }

    // 다음 카드 확인
    public Card Peek(int index = 0)
    {
        if (index < 0 || index >= cards.Count) return null;
        return cards[index]; // O(1)
    }

    public void Shuffle()
    {
        var list = new List<Card>(cards);
        cards.Clear();

        for (int i = 0; i < list.Count; i++)
        {
            int rand = Random.Range(i, list.Count);
            (list[i], list[rand]) = (list[rand], list[i]); // Swap
        }

        foreach (var card in list)
            cards.Add(card);
    }
}
