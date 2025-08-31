using UnityEngine;

public class Player_Run : IState
{
    private PlayerController player;
    public Player_Run(PlayerController player) { this.player = player; }
    public void Enter()
    {
        player.animator.Play("Run");
    }
    public void Update()
    {
        player.rigidBody.linearVelocity = new Vector2(player.moveInput * player.moveSpeed, player.rigidBody.linearVelocity.y);

        // 방향 전환
        if (player.moveInput != 0)
            player.transform.localScale = new Vector3(player.moveInput, 1, 1);

        if (player.moveInput == 0)
        {
            player.stateManager.TransitionTo(player.stateManager.idleState);
        }
        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
        {
            player.stateManager.TransitionTo(player.stateManager.jumpState);
        }
        if (!player.IsGrounded())
        {
            player.stateManager.TransitionTo(player.stateManager.fallState);
        }
    }
    public void Action()
    {
    }
    public void Exit()
    {
    }
}
