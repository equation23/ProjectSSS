using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR;

public class Player_Idle  : PlayerStateBase
{

    public Player_Idle(PlayerController player) : base(player)
    {
       
    }
    public override void Initialize()
    {
        cardTransitions["GunFire"] = player.stateManager.gunfireState;
        cardTransitions["SwordAttack"] = player.stateManager.swordAttackState;
    }
    public override void Enter() 
    {
        //Debug.Log("Move !!!");
        player.animator.Play("Idle"); 
    }
    public override void Update()
    {
        if (player.moveInput != 0)
            player.stateManager.TransitionTo(player.stateManager.runState);
        
        if (player.rigidBody.linearVelocity.y < -0.1f)
            player.stateManager.TransitionTo(player.stateManager.fallState);

        if (Input.GetKeyDown(KeyCode.Space))
            player.stateManager.TransitionTo(player.stateManager.jumpState);

        player.AttackInput();
    }
    public override void Exit()
    {
        player.ePrevState = EPlayerStates.idleState;
    }
}
