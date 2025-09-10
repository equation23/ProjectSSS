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
    public Player_WallSlide wallSlideState;
    public Player_WallJump wallJumpState;
    public Player_RunToIdle runToIdleState;
    public Player_Attack_GunFire gunfireState;
    public Player_Attack_GunRunFire gunRunfireState;


    public PlayerStateManager(PlayerController player)
    {
        this.idleState = new Player_Idle(player);
        this.jumpState = new Player_Jump(player);
        this.fallState = new Player_Fall(player);
        this.landState = new Player_Land(player);
        this.runState = new Player_Run(player);
        this.wallSlideState = new Player_WallSlide(player);
        this.wallJumpState = new Player_WallJump(player);
        this.runToIdleState = new Player_RunToIdle(player);
        this.gunfireState = new Player_Attack_GunFire(player);
        this.gunRunfireState = new Player_Attack_GunRunFire(player);
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
