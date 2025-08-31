using System.Threading;
using UnityEngine;

public class PlayerStateManager
{
    public IState CurrentState { get; private set; }

    public Player_Idle idleState;
    public Player_Jump jumpState;
    public Player_Fall fallState;
    public Player_Land landState;
    public Player_Run runState;


    public PlayerStateManager(PlayerController player)
    {
        this.idleState = new Player_Idle(player);
        this.jumpState = new Player_Jump(player);
        this.fallState = new Player_Fall(player);
        this.landState = new Player_Land(player);
        this.runState = new Player_Run(player);
    }
    public void Initialize(IState startingState)
    {
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
}
