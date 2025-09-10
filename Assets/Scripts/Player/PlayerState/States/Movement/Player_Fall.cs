using UnityEngine;

public class Player_Fall : IState
{

    private PlayerController player;
    public Player_Fall(PlayerController player) { this.player = player; }
    public void Enter()
    {
        player.animator.Play("JumpFall");
    }
    public void Update()
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
    public void Action()
    {
    }
    public void Exit()
    {
        player.ePrevState = EPlayerStates.fallState;
    }
}
