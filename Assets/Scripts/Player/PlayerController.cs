using UnityEngine;

public class PlayerController : MonoBehaviour {

    [Header("Settings")]
    public float JumpForce;

    public PlayerStateManager stateManager;

    [Header("References")]
    public Rigidbody2D rigidBody;

    [Header("References")]
    public BoxCollider2D boxCollider;   // Player의 Collider
    public LayerMask obstacleLayer;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); // Player에 Rigidbody2D 컴포넌트가 있어야 함
    }
    void Start()
    {
        stateManager = new PlayerStateManager(this);
        stateManager.Initialize(stateManager.idleState); // Idle 상태로 시작
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager != null)
        {
            stateManager.Update();
        }
    }

    public bool IsGrounded()
    {
        float extraHeight = 0.1f; // 살짝 여유를 둬야 잘 감지됨
        RaycastHit2D hit = Physics2D.BoxCast(
            boxCollider.bounds.center,                 // 콜라이더 중심
            boxCollider.bounds.size,                   // 콜라이더 크기
            0f,                                         // 회전 없음
            Vector2.down,                      // 아래 방향
            extraHeight,                       // 얼마나 밑으로 쏠지
            obstacleLayer                        // 체크할 레이어
        );

        return hit.collider != null;
    }
}