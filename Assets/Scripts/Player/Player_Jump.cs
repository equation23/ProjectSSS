using UnityEngine;

public class Player_Jump : IState
{
    private PlayerController player;

    public Player_Jump(PlayerController player) { this.player = player; }
    public void Enter()
    {
        player.rigidBody.AddForceY(player.JumpForce, ForceMode2D.Impulse);
    }
    public void Update()
    {
        
        if (player.IsGrounded() && player.rigidBody.linearVelocity.y <= 0)
        {
            player.stateManager.TransitionTo(player.stateManager.idleState);
        }
    }
    public void Action() 
    {
    }
    public void Exit() 
    { 
    }
}
