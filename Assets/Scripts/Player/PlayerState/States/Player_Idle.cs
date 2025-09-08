using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player_Idle : IState
{
    private PlayerController player;

    public Player_Idle(PlayerController player) {  this.player = player; }
    public void Enter() 
    {
        //Debug.Log("Move !!!");
        player.animator.Play("Idle"); 
    }
    public void Update()
    {
        if (player.moveInput != 0)
            player.stateManager.TransitionTo(player.stateManager.runState);
        
        if (player.rigidBody.linearVelocity.y < -0.1f)
            player.stateManager.TransitionTo(player.stateManager.fallState);

        if (Input.GetKeyDown(KeyCode.Space))
            player.stateManager.TransitionTo(player.stateManager.jumpState);
 
    }
    public void Action() 
    {
    }
    public void Exit()
    {
        player.ePrevState = EPlayerStates.idleState;
    }
}
