using UnityEngine;

public class Deck_Basic : Deck
{
    
    override public void Initialize()
    {
     
      

        for (int i = 0; i < 3; i++)
        {
            Card_Attack_GunFire gunFire = new Card_Attack_GunFire();
            AddCard(gunFire);
        }
           

        for (int i = 0; i < 3; i++)
        {
            Card_Attack_Sword swordAttack = new Card_Attack_Sword();

            AddCard(swordAttack);
        }

    }
}
