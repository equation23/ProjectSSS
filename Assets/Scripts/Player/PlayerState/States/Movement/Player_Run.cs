using UnityEngine;

public class Player_Run : PlayerStateBase
{

    public Player_Run(PlayerController player) : base(player)
    {
      
    }
    public override void Initialize()
    {
        inputTransitions[InputType.Jump] = player.stateManager.jumpState;

        cardTransitions[CardEnum.GUNFIRE] = player.stateManager.gunRunfireState;
    }
    public override void Enter()
    {
        player.animator.Play("Run");
    }
    public override void Update()
    {

        player.MovePlayer();

        if (player.moveInput == 0)
        {
            player.stateManager.TransitionTo(player.stateManager.runToIdleState);
        }
        //if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
        //{
        //    player.stateManager.TransitionTo(player.stateManager.jumpState);
        //}
        if (!player.IsGrounded())
        {
            player.stateManager.TransitionTo(player.stateManager.fallState);
        }


    }

    public override void Exit()
    {
        player.ePrevState = EPlayerStates.runState;
    }
    public override void HandleInput(InputType input)
    {
        if (inputTransitions.TryGetValue(input, out var nextState))
            player.stateManager.TransitionTo(nextState);
    }
}
