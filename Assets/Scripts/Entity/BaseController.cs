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

    // �̵�
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
