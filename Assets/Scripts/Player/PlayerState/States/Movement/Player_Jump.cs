using UnityEngine;

public class Player_Jump : PlayerStateBase
{

    public Player_Jump(PlayerController player) :base(player)
    {

    }
    public override void Initialize()
    {

    }
    public override void Enter()
    {
        player.animator.Play("Jump");
        player.rigidBody.AddForceY(player.jumpForce, ForceMode2D.Impulse);
    }
    public override void Update()
    {       
        // 방향 전환
        if (player.moveInput != 0)
            player.transform.localScale = new Vector3(player.moveInput, 1, 1);

        // player.rigidBody.linearVelocity = new Vector2(player.moveInput * player.moveSpeed, player.rigidBody.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.Space) && player.IsTouchingWall())
        {
            player.stateManager.TransitionTo(player.stateManager.wallJumpState);
            return;
        }
        player.MovePlayer();

        if (player.rigidBody.linearVelocity.y < 0)
        {
            player.stateManager.TransitionTo(player.stateManager.fallState);
        }
    }
    public override void CardAction(string CardName) 
    {
    }
    public override void Exit() 
    {
        player.ePrevState = EPlayerStates.jumpState;
    }
}
