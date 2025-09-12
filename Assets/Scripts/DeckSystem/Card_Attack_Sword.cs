using UnityEngine;

public class Card_Attack_Sword : Card
{
    //string CardTag = "SwordAttack";

    public Card_Attack_Sword ()
    {
        data = Resources.Load<CardData>("CardData/CardData_SwordAttack_A");
        cardEnum = CardEnum.SWORDATTACK_A;

    }

    public override bool Using_Card(CardUsing_Interface owner)
    {
        if (owner == null) return false;
        return owner.Use_Attack_Card(cardEnum,data);

       
    }
}
