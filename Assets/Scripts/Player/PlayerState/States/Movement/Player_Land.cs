using UnityEngine;

public class Player_Land : PlayerStateBase
{

    public Player_Land(PlayerController player) : base(player)
    {
      
    }
    public override void Initialize()
    {
        inputTransitions[InputType.Jump] = player.stateManager.jumpState;

        cardTransitions[CardEnum.GUNFIRE] = player.stateManager.gunfireState;
    }
    public override void Enter()
    {
        //player.rigidBody.linearVelocity = new Vector2(0, player.rigidBody.linearVelocity.y);

        player.animator.Play("Land");
    }
    public override void Update()
    {
        player.MovePlayer();
        AnimatorStateInfo stateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Land") && stateInfo.normalizedTime >= 1.0f)
        {
            player.stateManager.TransitionTo(player.stateManager.idleState);
        }
        if (player.moveInput != 0)
            player.stateManager.TransitionTo(player.stateManager.runState);

        if (player.rigidBody.linearVelocity.y < -0.1f)
            player.stateManager.TransitionTo(player.stateManager.fallState);



    }
    public override void Exit()
    {
        player.ePrevState = EPlayerStates.landState;
    }
    public override void HandleInput(InputType input)
    {
        if (inputTransitions.TryGetValue(input, out var nextState))
            player.stateManager.TransitionTo(nextState);
    }
}

