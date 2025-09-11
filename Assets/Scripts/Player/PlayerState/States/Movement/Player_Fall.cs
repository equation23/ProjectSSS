using UnityEngine;

public class Player_Fall : PlayerStateBase
{
    public Player_Fall(PlayerController player) : base(player)
    {

    }
    public override void Initialize()
    {

    }
    public override void Enter()
    {
        player.animator.Play("JumpFall");
    }
    public override void Update()
    {
        // 방향 전환
        if (player.moveInput != 0)
            player.transform.localScale = new Vector3(player.moveInput, 1, 1);

        // player.rigidBody.linearVelocity = new Vector2(player.moveInput * player.moveSpeed, player.rigidBody.linearVelocity.y);
        if (player.moveInput != 0 && player.ePrevState == EPlayerStates.wallJumpState)
        {
            player.MovePlayer();
            player.ePrevState = EPlayerStates.fallState;
        }
        else if(player.ePrevState != EPlayerStates.wallJumpState)
           player.MovePlayer();

        if (player.IsGrounded())
            player.stateManager.TransitionTo(player.stateManager.landState);
        else if (player.IsTouchingWall())
            player.stateManager.TransitionTo(player.stateManager.wallSlideState);

            
        
    }
    public override void Exit()
    {
        player.ePrevState = EPlayerStates.fallState;
    }

    public override void HandleInput(InputType input)
    {
        
    }
}
