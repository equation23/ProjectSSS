using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour, CardUsing_Interface, IAttack_Interface
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

    [Header("Combat")]
    public Combat_Sword_Collider swordCollider;
    public Transform firePoint;
    public CardHand GetHand() { return hand; }

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        animator = GetComponent<Animator>();
        
        // Card Initialize
        deck = new Deck_Basic();
        deck.Initialize();
        hand = new CardHand(this, deck);

    }
    void Start()
    {
        Managers.Input.KeyAction += HandleMoveInput;
        Managers.Input.KeyAction += AttackInput;
        Managers.UI.Initialize(hand, deck);

        stateManager = new PlayerStateManager(this);
        stateManager.Initialize(stateManager.idleState); // Idle 상태로 시작

     
    }

    // Update is called once per frame
    void Update()
    {

        //HandleMoveInput();

        if (stateManager != null)
        {
            //moveInput = Input.GetAxisRaw("Horizontal");
            stateManager.Update();
        }
    }




    #region 지형 충돌 처리
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

    #endregion


    void HandleMoveInput()
    {
        // 키 눌린 순간 기록
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            leftPressTime = Time.time;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            rightPressTime = Time.time;

        // 현재 눌린 상태
        bool left = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

        // 최종 이동 방향 계산
        if (left && right)
            moveInput = (leftPressTime > rightPressTime) ? -1f : 1f; // 늦게 누른 쪽 우선
        else if (left)
            moveInput = -1f;
        else if (right)
            moveInput = 1f;
        else
            moveInput = 0f;

        // 점프 키 입력
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateManager.HandleInput(InputType.Jump);
        }

    }
    public void MovePlayer()
    {
        if (moveInput != 0)
            transform.localScale = new Vector3(moveInput, 1, 1);
        Vector2 velocity = rigidBody.linearVelocity;
        velocity.x = moveInput * moveSpeed;
        rigidBody.linearVelocity = velocity;
    }

    public bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    public void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (GetHand().UseLeftCard())
            {
                Managers.UI.UpdateCardUI();
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if (GetHand().UseRightCard())
            {
Managers.UI.UpdateCardUI();
            }
        }
    }
    public bool Use_Attack_Card(CardEnum tag, CardData cardData) 
    {
        return stateManager.TransitionToAttack(tag, cardData);

      
    }

    public void TakeDamage(int damage)
    {
        Debug.Log("PlayerDamaged"+ damage);
    }

    public void ShootBullet(GunCardData data)
    {
        if (data == null || data.bulletPrefab == null || firePoint == null) return;

        // 총알 생성
        GameObject bulletObj = Instantiate(data.bulletPrefab, firePoint.position, Quaternion.identity);

        // 방향 계산
        Vector2 dir = IsFacingRight() ? Vector2.right : Vector2.left;

        // Bullet.cs 초기화 호출
        bulletObj.GetComponent<Bullet>().Initialize(data, dir, boxCollider);
    }
}