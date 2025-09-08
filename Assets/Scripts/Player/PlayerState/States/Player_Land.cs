using UnityEngine;

public class Player_Land : IState
{
    private PlayerController player;
    public Player_Land(PlayerController player) { this.player = player; }
    public void Enter()
    {
        //player.rigidBody.linearVelocity = new Vector2(0, player.rigidBody.linearVelocity.y);

        player.animator.Play("Land");
    }
    public void Update()
    {
        player.MovePlayer();
        AnimatorStateInfo stateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Land") && stateInfo.normalizedTime >= 1.0f)
        {
            player.stateManager.TransitionTo(player.stateManager.idleState);
        }
    }
    public void Action()
    {
    }
    public void Exit()
    {
        player.ePrevState = EPlayerStates.landState;
    }
}

