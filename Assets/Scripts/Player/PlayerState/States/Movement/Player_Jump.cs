using UnityEngine;

public class Player_Jump : PlayerStateBase
{

    public Player_Jump(PlayerController player) :base(player)
    {

    }
    public override void Initialize()
    {
    
    }
    public override void Enter(CardData cardData)
    {

    }
    public override void Enter()
    {
        player.animator.Play("Jump");
        player.rigidBody.AddForceY(player.movementController.jumpForce, ForceMode2D.Impulse);
    }
    public override void Update()
    {       

        player.MovePlayer();

        if (player.rigidBody.linearVelocity.y < 0)
        {
            player.stateManager.TransitionTo(player.stateManager.fallState);
        }
    }

    public override void Exit() 
    {
        player.ePrevState = EPlayerStates.jumpState;
    }
    public override void HandleInput(InputType input)
    {
        if (input == InputType.Jump)
        {
            if (!player.movementController.IsGrounded() && player.movementController.IsTouchingWall())
            {
                player.stateManager.TransitionTo(player.stateManager.wallJumpState);
            }
        }
    }
}
