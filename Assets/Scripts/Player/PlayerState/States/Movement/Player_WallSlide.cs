using UnityEngine;

public class Player_WallSlide : PlayerStateBase

{

    public Player_WallSlide(PlayerController player) :base(player)
    {

    }
    private float wallSlideSpeed = -2f;

    public override void Initialize()
    {
        inputTransitions[InputType.Jump] = player.stateManager.wallJumpState;
    }
    public override void Enter(CardData cardData)
    {

    }

    public override void Enter()
    {
        player.animator.Play("WallSlide");
    }
    public override void Update()
    {
        // 속도를 항상 일정하게 고정
        Vector2 velocity = player.rigidBody.linearVelocity;
        velocity.y = wallSlideSpeed;
        player.rigidBody.linearVelocity = velocity;

        // player.rigidBody.linearVelocity = new Vector2(player.moveInput * player.moveSpeed, player.rigidBody.linearVelocity.y);
        player.MovePlayer();

        if (player.movementController.IsGrounded())
            player.stateManager.TransitionTo(player.stateManager.landState);
        else if (!player.movementController.IsTouchingWall())
            player.stateManager.TransitionTo(player.stateManager.fallState);
    }

    public override void Exit()
    {
        player.ePrevState = EPlayerStates.wallSlideState;
    }

    public override void HandleInput(InputType input)
    {
        if (inputTransitions.TryGetValue(input, out var nextState))
            player.stateManager.TransitionTo(nextState);
    }
}
