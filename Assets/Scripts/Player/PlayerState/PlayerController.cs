using System.Threading;
using UnityEngine;

public class PlayerController : MonoBehaviour, CardUsing_Interface, IAttack_Interface
{

    public PlayerStateManager stateManager;

    [Header("References")]
    public Rigidbody2D rigidBody;

    [HideInInspector] public Animator animator;

    [Header("References")]
    public BoxCollider2D boxCollider;   // Player의 Collider
    public LayerMask obstacleLayer;



    [HideInInspector] public float moveInput;
    public MovementController movementController = new MovementController();

    public EPlayerStates ePrevState;

    //private float raycastDistance = 0.1f;

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
        movementController.Initialize(rigidBody, boxCollider,transform, obstacleLayer);

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
            movementController.Move(moveInput);
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
        Vector2 dir = movementController.IsFacingRight() ? Vector2.right : Vector2.left;

        // Bullet.cs 초기화 호출
        bulletObj.GetComponent<Bullet>().Initialize(data, dir, boxCollider);
    }
}