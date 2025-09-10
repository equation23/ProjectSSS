using UnityEngine;

public class Card_Attack_Sword : Card
{
    //string CardTag = "SwordAttack";
    CardEnum cardEnum = CardEnum.SWORDATTACK_A;
    public override bool Using_Card(CardUsing_Interface owner)
    {
        if (owner == null) return false;
        return owner.Use_Attack_Card(cardEnum);

       
    }
}
