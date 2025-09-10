using UnityEngine;

public class Player_WallJump : PlayerStateBase
{

    public Player_WallJump(PlayerController player) : base(player)
    {

    }
    public override void Initialize()
    {

    }
    public override void Enter()
    {

        player.animator.Play("WallJump");

        // 기존 속도를 리셋
        player.rigidBody.linearVelocity = Vector2.zero;

        int direction = player.IsFacingRight() ? -1 : 1;
        // 벽을 붙잡은 쪽 반대 방향으로 점프하려면 부호 반전 필요

        // 스프라이트 반전
        player.transform.localScale = new Vector3(direction, 1, 1);


        // 수평 속도와 수직 힘을 동시에 적용
        Vector2 jumpVelocity = new Vector2(direction * player.moveSpeed, player.jumpForce);
        player.rigidBody.AddForce(jumpVelocity, ForceMode2D.Impulse);
       // player.rigidBody.linearVelocity = jumpVelocity;   // 속도를 직접 세팅
    }
    public override void Update()
    {


        if (player.rigidBody.linearVelocity.y < 0)
        {
            player.stateManager.TransitionTo(player.stateManager.fallState);
        }
    }

    public override void Exit()
    {
        player.ePrevState = EPlayerStates.wallJumpState;
    }
}
