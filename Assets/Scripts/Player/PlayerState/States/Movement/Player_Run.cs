using UnityEngine;

public class Player_Run : PlayerStateBase
{

    public Player_Run(PlayerController player) : base(player)
    {
      
    }
    public override void Initialize()
    {
        cardTransitions["GunFire"] = player.stateManager.gunRunfireState;
    }
    public override void Enter()
    {
        player.animator.Play("Run");
    }
    public override void Update()
    {
        //  player.rigidBody.linearVelocity = new Vector2(player.moveInput * player.moveSpeed, player.rigidBody.linearVelocity.y);

        player.MovePlayer();

        // 방향 전환
        if (player.moveInput != 0)
            player.transform.localScale = new Vector3(player.moveInput, 1, 1);

        if (player.moveInput == 0)
        {
            player.stateManager.TransitionTo(player.stateManager.runToIdleState);
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
        {
            player.stateManager.TransitionTo(player.stateManager.jumpState);
        }
        if (!player.IsGrounded())
        {
            player.stateManager.TransitionTo(player.stateManager.fallState);
        }

        player.AttackInput();
    }

    public override void Exit()
    {
        player.ePrevState = EPlayerStates.runState;
    }
}
