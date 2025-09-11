using UnityEngine;
using UnityEngine.XR;

public class Player_Attack_GunFire : PlayerStateBase
{

    public Player_Attack_GunFire(PlayerController player) :base(player)
    {

    }
    public override void Initialize()
    {

    }
    public override void Enter()
    {
        //player.rigidBody.linearVelocity = new Vector2(0, player.rigidBody.linearVelocity.y);

        player.animator.Play("GunFire");

        player.GetHand().ConsumePendingCard();
    }
    public override void Update()
    {

        AnimatorStateInfo stateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("GunFire") && stateInfo.normalizedTime >= 1.0f)
        {
            player.stateManager.TransitionTo(player.stateManager.idleState);
        }

    }
    public override void Exit()
    {
        player.ePrevState = EPlayerStates.attack_GunFire;

    }

    public override void HandleInput(InputType input)
    {

    }
}
