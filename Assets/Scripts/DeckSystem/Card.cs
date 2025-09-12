using UnityEngine;
public enum CardEnum
{
    GUNFIRE, SWORDATTACK_A,
}

public class Card
{
    protected CardData data;
    protected CardEnum cardEnum;

    public CardData GetData() => data;

    public CardEnum GetCardEnum() {  return cardEnum; }
    virtual public bool Using_Card(CardUsing_Interface owner) { return false; }
}
