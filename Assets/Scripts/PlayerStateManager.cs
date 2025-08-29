using System.Threading;
using UnityEngine;

public class PlayerStateManager
{
    public IState CurrentState { get; private set; }

    public Player_Idle idleState;
    public Player_Jump jumpState;


    public PlayerStateManager(PlayerController player)
    {
        this.idleState = new Player_Idle(player);
        this.jumpState = new Player_Jump(player);
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
