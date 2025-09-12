using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    private Queue<Card> cards = new Queue<Card>();
    private Queue<Card> tomb = new Queue<Card>();

    virtual public void Initialize() { }
    // 덱에 카드 추가
    public void AddCard(Card card)
    {
        cards.Enqueue(card);
    }

    // 덱에서 카드 뽑기
    public Card DrawCard()
    {
        if (cards.Count > 0)
            return cards.Dequeue(); 
        else
            return null; 
    }


    // 덱에 몇 장 남았는지 확인
    public int Count()
    {
        return cards.Count;
    }

    public void AddTomb(Card card)
    {
        tomb.Enqueue(card);
    }

    // 다음 카드 확인
    public Card Peek(int index = 0)
    {
        if (index < 0 || index >= cards.Count) return null;
        return new List<Card>(cards)[index]; 
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
            cards.Enqueue(card);
    }
}
