using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour
{
    // ��� ĳ���Ϳ� �������� ��ɵ��� �����ϴ� �⺻ ��Ʈ�ѷ�
    protected Rigidbody2D _rigidbody;
    protected Animation anim;

    [SerializeField] private SpriteRenderer characterRenderer;
    [SerializeField] private Transform weaponPivot;

    // ������ �ٷ�� Ŭ����
    protected StatHandler statHandler;

    // �̵��ϴ� ����
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get => movementDirection; } 

    // �ٶ󺸴� ����
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

    // �̵�
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

    // �ٴ��� ����ִ��� Ȯ��
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

    // ��ȣ�ۿ� �̺�Ʈ��

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

    // �̺�Ʈ Ʈ����
    protected virtual void HandleEventTrigger()
    {

    }

}
