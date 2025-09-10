using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;
using UnityEngine;
using static UnityEditor.VersionControl.Asset;

public class PlayerStateManager
{
    public IState CurrentState { get; private set; }

    public Player_Idle idleState;
    public Player_Jump jumpState;
    public Player_Fall fallState;
    public Player_Land landState;
    public Player_Run runState;
    public Player_WallSlide wallSlideState;
    public Player_WallJump wallJumpState;
    public Player_RunToIdle runToIdleState;
    public Player_Attack_GunFire gunfireState;
    public Player_Attack_GunRunFire gunRunfireState;
    public Player_Attack_Sword swordAttackState;

    private List<IState> states;
    public PlayerStateManager(PlayerController player)
    {
        states = new List<IState> ();
        idleState = AddState<Player_Idle>(player, states);
        jumpState = AddState<Player_Jump>(player, states);
        fallState = AddState<Player_Fall>(player, states);
        landState = AddState<Player_Land>(player, states);
        runState = AddState<Player_Run>(player, states);
        wallSlideState = AddState<Player_WallSlide>(player, states);
        wallJumpState = AddState<Player_WallJump>(player, states);
        runToIdleState = AddState<Player_RunToIdle>(player, states);
        gunfireState = AddState<Player_Attack_GunFire>(player, states);
        gunRunfireState = AddState<Player_Attack_GunRunFire>(player, states);
        swordAttackState = AddState<Player_Attack_Sword>(player, states);
    }
    public void Initialize(IState startingState)
    {
        for (int i = 0; i < states.Count; i++)
            states[i].Initialize();
  

        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        if (CurrentState != null)
        {
            CurrentState.Update();
        }
    }

    public void TransitionToAttack(string cardName)
    {
        CurrentState.CardAction(cardName);
    }
    private T AddState<T>(PlayerController player, List<IState> states) where T : IState
    {
        var state = (T)Activator.CreateInstance(typeof(T), new object[] { player });
        states.Add(state);
        return state;
    }
}
