using UnityEngine;

public class Deck_Gun_Pistol : Deck
{
    
    override public void Initialize()
    {
        Card_Attack_GunFire gunFire = new Card_Attack_GunFire();

        for (int i = 0; i < 7; i++)
            AddCard(gunFire);

    }
}
