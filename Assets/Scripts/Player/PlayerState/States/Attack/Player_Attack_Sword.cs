using UnityEngine;

public class Player_Attack_Sword : PlayerStateBase
{

    public Player_Attack_Sword(PlayerController player) : base(player)
    {

    }
    public override void Initialize()
    {

    }
    public override void Enter(CardData cardData)
    {
        player.animator.Play("SwordAttack");

        player.GetHand().ConsumePendingCard();
        player.swordCollider.CollisionStart(cardData.Damage,player.boxCollider);
    }

    public override void Enter()
    {
        //player.rigidBody.linearVelocity = new Vector2(0, player.rigidBody.linearVelocity.y);

        player.animator.Play("SwordAttack");

        player.GetHand().ConsumePendingCard();
    }
    public override void Update()
    {

        AnimatorStateInfo stateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("SwordAttack") && stateInfo.normalizedTime >= 1.0f)
        {
            player.stateManager.TransitionTo(player.stateManager.idleState);
        }

    }
    public override void Exit()
    {
        player.ePrevState = EPlayerStates.attack_SwordAttack;

    }

    public override void HandleInput(InputType input)
    {

    }
}
