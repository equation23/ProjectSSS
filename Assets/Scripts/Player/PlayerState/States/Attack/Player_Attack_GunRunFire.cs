using UnityEngine;

public class Player_Attack_GunRunFire : IState
{
    private PlayerController player;
    public Player_Attack_GunRunFire(PlayerController player) { this.player = player; }

    public void Enter()
    {
        //player.rigidBody.linearVelocity = new Vector2(0, player.rigidBody.linearVelocity.y);

        player.animator.Play("GunRunFire");
    }
    public void Update()
    {
        player.MovePlayer();
        // 방향 전환
        if (player.moveInput != 0)
            player.transform.localScale = new Vector3(player.moveInput, 1, 1);

        if (Input.GetKeyDown(KeyCode.Space) && player.IsGrounded())
            player.stateManager.TransitionTo(player.stateManager.jumpState);

        if (!player.IsGrounded())
            player.stateManager.TransitionTo(player.stateManager.fallState);
        if (player.moveInput == 0)
        {
            player.stateManager.TransitionTo(player.stateManager.runToIdleState);
        }
        AnimatorStateInfo stateInfo = player.animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("GunRunFire") && stateInfo.normalizedTime >= 1.0f)
        {

            if (player.moveInput != 0)
            {
                player.stateManager.TransitionTo(player.stateManager.runState);
            }
        }
       
    }
    public void Action()
    {
    }
    public void Exit()
    {
        player.ePrevState = EPlayerStates.attack_GunRunFire;

    }
}
