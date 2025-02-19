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

    
    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
        statHandler = GetComponent<StatHandler>();

        
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
        HandleJump();
        HandleInteraction();
        HandleEventTrigger();
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
        direction = direction * statHandler.Speed;

        _rigidbody.velocity = direction;
    }

    private void Rotate(Vector2 dirction)
    {
        float rotZ = Mathf.Atan2(dirction.y, dirction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;

        if (weaponPivot != null)
        {
            weaponPivot.rotation = Quaternion.Euler(0, 9, rotZ);
        }
        

    }

    // 바닥을 밟고있는지 확인
    protected virtual bool isGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        return hit.collider != null;
    }

    protected virtual void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            _rigidbody.AddForce(Vector2.up * statHandler.JumpForece);
            
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
