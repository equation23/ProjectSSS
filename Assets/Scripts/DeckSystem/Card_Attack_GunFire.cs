using UnityEngine;

public class Card_Attack_GunFire :Card
{
    //string CardTag = "GunFire";

    public Card_Attack_GunFire()
    {
        data = Resources.Load<CardData>("CardData/CardData_GunFire");
        cardEnum = CardEnum.GUNFIRE;
    }
    public override bool Using_Card(CardUsing_Interface owner)
    {
        if (owner == null) return false;
        return owner.Use_Attack_Card(cardEnum);

      
    }
}
