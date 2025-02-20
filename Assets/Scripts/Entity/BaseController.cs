using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    // 모든 캐릭터에 공통적인 기능들을 정의하는 기본 컨트롤러
    protected Rigidbody2D _rigidbody;
    protected Animation anim;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    // 스탯을 다루는 클래스
    protected StatHandler statHandler;

    // 이동하는 방향
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get => movementDirection; } 

    // 바라보는 방향
    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 LookDirection {  get => lookDirection; }

    protected JumpController jumpController;

    
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        statHandler = GetComponent<StatHandler>();
        jumpController = GetComponent<JumpController>();

        
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        HandleInteraction();
        HandleEventTrigger();

        if (Input.GetKeyDown(KeyCode.Space))
            jumpController.Jump();
    }

    protected virtual void FixedUpdate()
    {
        Movement(movementDirection);
    }


    protected virtual void HandleAction()
    {

    }

    // 이동
    private void Movement(Vector2 direction)
    {
        float jumpY = jumpController != null ? jumpController.CurrentJumpY : 0f;
        direction = direction * statHandler.Speed;

        _rigidbody.velocity = direction + new Vector2(0, jumpController.CurrentJump());
    }

    private void Rotate(Vector2 dirction)
    {
        float rotZ = Mathf.Atan2(dirction.y, dirction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;

        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0f, 0f, rotZ);
        }
        

    }


    // 상호작용 이벤트들

    protected virtual void HandleInteraction()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            OnInteract();
        }
    }

    protected virtual void OnInteract()
    {

    }

    // 이벤트 트리거
    protected virtual void HandleEventTrigger()
    {

    }

}
