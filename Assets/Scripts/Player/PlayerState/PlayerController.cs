using UnityEngine;

public class PlayerController : MonoBehaviour, CardUsing_Interface
{

    [Header("Settings")]
    public float jumpForce = 12f;
    public float moveSpeed;
    public float wallSlideSpeed = 2f;
    public float wallJumpForce = 12f;

    public PlayerStateManager stateManager;

    [Header("References")]
    public Rigidbody2D rigidBody;

    [HideInInspector] public Animator animator;

    [Header("References")]
    public BoxCollider2D boxCollider;   // Player의 Collider
    public LayerMask obstacleLayer;



    [HideInInspector] public float moveInput;
    public EPlayerStates ePrevState;

    private float raycastDistance = 0.1f;
    // 마지막 입력 시간 기록
    private float leftPressTime = -1f;
    private float rightPressTime = -1f;


    private Deck deck;
    private CardHand hand;


    public CardHand GetHand() { return hand; }
    private void Awake()
    {
        rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>(); // Player에 Rigidbody2D 컴포넌트가 있어야 함

        // Card Initialize
        deck = new Deck_Gun_Pistol();
        deck.Initialize();
        hand = new CardHand(this, deck);

    }
    void Start()
    {
        stateManager = new PlayerStateManager(this);
        stateManager.Initialize(stateManager.idleState); // Idle 상태로 시작
    }

    // Update is called once per frame
    void Update()
    {
  
        HandleInput();

        if (stateManager != null)
        {
            //moveInput = Input.GetAxisRaw("Horizontal");
            stateManager.Update();
        }
    }

    public bool IsGrounded()
    {
        float extraHeight = 0.1f;

        // X폭은 살짝 줄이고 Y는 얇게
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * 0.7f, 0.05f);

        // origin = Collider 바닥에서 살짝 아래
        Vector2 origin = new Vector2(
            boxCollider.bounds.center.x,
            boxCollider.bounds.min.y - 0.01f
        );

        RaycastHit2D hit = Physics2D.BoxCast(
            origin,
            boxSize,
            0f,
            Vector2.down,
            extraHeight,
            obstacleLayer
        );

        return hit.collider != null;
    }
    public bool IsTouchingWall()
    {

        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        // 중심에서 시작
        Vector2 origin = bounds.center;
        // 박스 크기: Y축을 살짝 줄여서 발판을 안 건드리도록
        Vector2 size = new Vector2(bounds.size.x, bounds.size.y * 0.8f);

        int direction = IsFacingRight() ? 1 : -1;
        bool isWall = Physics2D.BoxCast(
            origin,
            size,
            0f,
            Vector2.right * direction,
            raycastDistance,
            obstacleLayer
        );
        return isWall;
    }

    private void OnDrawGizmos()
    {
        if (!boxCollider) return;
        Gizmos.color = Color.red;
        Vector2 boxSize = new Vector2(boxCollider.bounds.size.x * 0.7f, 0.05f);
        Vector2 origin = new Vector2(boxCollider.bounds.center.x, boxCollider.bounds.min.y - 0.01f);
        Gizmos.DrawWireCube(origin, boxSize);
    }

    void HandleInput()
    {
        // 키 눌림 시간 기록
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            leftPressTime = Time.time;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            rightPressTime = Time.time;

        // 현재 눌린 상태
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        // 최종 이동 방향 계산
        if (left && right)
            moveInput = leftPressTime > rightPressTime ? -1f : 1f; // 늦게 누른 쪽 우선
        else if (left) moveInput = -1f;
        else if (right) moveInput = 1f;
        else moveInput = 0f;
    }
    public void MovePlayer()
    {
        Vector2 velocity = rigidBody.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rigidBody.linearVelocity = velocity;
    }

    public bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    public void Use_Attack_Card(string cardName) 
    { 
    
    }

}