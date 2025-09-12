using UnityEngine;

public class Card_Attack_GunFire :Card
{
    //string CardTag = "GunFire";

    public Card_Attack_GunFire()
    {
        data = Resources.Load<CardData>("CardData/GunCardData_GunFire");
        cardEnum = CardEnum.GUNFIRE;
    }
    public override bool Using_Card(CardUsing_Interface owner)
    {
        if (owner == null) return false;

        GunCardData gunData = data as GunCardData;
        if (gunData != null)
        {
            return owner.Use_Attack_Card(cardEnum, gunData);
        }

        return false;

    }
}
