using UnityEngine;

public class Card_Attack_GunFire :Card
{
    //string CardTag = "GunFire";
    CardEnum CardEnum = CardEnum.GUNFIRE;
    public override bool Using_Card(CardUsing_Interface owner)
    {
        if (owner == null) return false;
        return owner.Use_Attack_Card(CardEnum);

      
    }
}
