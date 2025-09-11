using System.Collections.Generic;
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

        inputTransitions[InputType.Jump] = player.stateManager.jumpState;

        cardTransitions[CardEnum.GUNFIRE] = player.stateManager.gunfireState;
        cardTransitions[CardEnum.SWORDATTACK_A] = player.stateManager.swordAttackState;
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


    }
    public override void Exit()
    {
        player.ePrevState = EPlayerStates.idleState;
    }
    public override void HandleInput(InputType input)
    {
        if (inputTransitions.TryGetValue(input, out var nextState))
            player.stateManager.TransitionTo(nextState);
    }
}
