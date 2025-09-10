using UnityEngine;

public class Player_RunToIdle : PlayerStateBase
{

    public Player_RunToIdle(PlayerController player) :base(player)
    {
      
    }
    public override void Initialize()
    {
        cardTransitions[CardEnum.GUNFIRE] = player.stateManager.gunfireState;
    }
    public override void Enter()
    {
        player.animator.Play("RunToIdle");
    }
    public override void Update()
    {
        //  player.rigidBody.linearVelocity = new Vector2(player.moveInput * player.moveSpeed, player.rigidBody.linearVelocity.y);

        player.MovePlayer();

        AnimatorStateInfo stateInfo = player.animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("RunToIdle") && stateInfo.normalizedTime >= 1.0f)
            player.stateManager.TransitionTo(player.stateManager.idleState);

        if (player.moveInput != 0)
            player.stateManager.TransitionTo(player.stateManager.runState);

        if (player.rigidBody.linearVelocity.y < -0.1f)
            player.stateManager.TransitionTo(player.stateManager.fallState);

        if (Input.GetKeyDown(KeyCode.Space))
            player.stateManager.TransitionTo(player.stateManager.jumpState);

        player.AttackInput();

    }
    public override void Exit()
    {
        player.ePrevState = EPlayerStates.runToIdleState;
    }
}
