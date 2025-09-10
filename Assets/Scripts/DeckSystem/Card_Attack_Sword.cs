using UnityEngine;

public class Card_Attack_Sword : Card
{
    string CardTag = "SwordAttack";

    public override void Using_Card(CardUsing_Interface owner)
    {
        if (owner == null) return;
        owner.Use_Attack_Card(CardTag);
    }
}
