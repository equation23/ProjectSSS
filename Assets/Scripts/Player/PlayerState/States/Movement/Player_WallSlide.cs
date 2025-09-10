using UnityEngine;

public class Player_WallSlide : IState
{
    private PlayerController player;
    public Player_WallSlide(PlayerController player) { this.player = player; }
    private float wallSlideSpeed = -2f;
    public void Enter()
    {
        player.animator.Play("WallSlide");
    }
    public void Update()
    {
        // 속도를 항상 일정하게 고정
        Vector2 velocity = player.rigidBody.linearVelocity;
        velocity.y = wallSlideSpeed;
        player.rigidBody.linearVelocity = velocity;

        // 방향 전환
        if (player.moveInput != 0)
            player.transform.localScale = new Vector3(player.moveInput, 1, 1);

        // player.rigidBody.linearVelocity = new Vector2(player.moveInput * player.moveSpeed, player.rigidBody.linearVelocity.y);
        player.MovePlayer();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.stateManager.TransitionTo(player.stateManager.wallJumpState);
            return;
        }

        if (player.IsGrounded())
            player.stateManager.TransitionTo(player.stateManager.landState);
        else if (!player.IsTouchingWall())
            player.stateManager.TransitionTo(player.stateManager.fallState);
    }
    public void Action()
    {
    }
    public void Exit()
    {
        player.ePrevState = EPlayerStates.wallSlideState;
    }
}
