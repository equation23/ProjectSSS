using UnityEngine;

public class Player_Attack_GunFire : IState
{
    private PlayerController player;
    public Player_Attack_GunFire(PlayerController player) { this.player = player; }

    public void Enter()
    {
        //player.rigidBody.linearVelocity = new Vector2(0, player.rigidBody.linearVelocity.y);

        player.animator.Play("GunFire");
    }
    public void Update()
    {

        AnimatorStateInfo stateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("GunFire") && stateInfo.normalizedTime >= 1.0f)
        {
            player.stateManager.TransitionTo(player.stateManager.idleState);
        }

    }
    public void Action()
    {
    }
    public void Exit()
    {
        player.ePrevState = EPlayerStates.attack_GunFire;

    }
}
