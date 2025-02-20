using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    // 점프 중 이동할 수 있게 끔 구현. 그러려면 일단 점프하는 y축을 점프 상승중일땐 y+ 하강중일 땐 y-를 해보자

    [Header("Jump Setting")]
    [Range(1f, 5f)][SerializeField] private float jumpHeight = 1;
    public float JumpHeigt
    {
        get => jumpHeight;
        set => jumpHeight = Mathf.Clamp(value, 1f, 5f);
    }

    [Range(0.5f, 2f)][SerializeField] private float jumpDuration = 1f;
    public float JumpDuration
    {
        get => jumpDuration;
        set => jumpDuration = Mathf.Clamp(value, 0.5f, 2f);
    }
    // 점프의 최대 횟수
    [Range(1, 3)][SerializeField] private int maxJumpCount = 1;
    public int MaxJumpCount
    {
        get => maxJumpCount;
        set => maxJumpCount = Mathf.Clamp(value, 1, 3);
    }

    private int currentJumpCount = 0; //현재의 점프 횟수
    private Vector3 position;
    private Coroutine jumpCoroutine;
    // 점프할 때 추가해줄 y값
    public float CurrentJumpY { get; private set; } = 0f;
    public int jumpYNum = 0;


    private void Awake()
    {
        position = transform.localPosition;
    }

    public void Jump()
    {
        if (currentJumpCount < maxJumpCount)
        {
            // 점프 시 시작  지점의 위치를 현재위치로 갱신
            if (currentJumpCount == 0)
                position = transform.localPosition;

            if (jumpCoroutine != null)
            {
                StopCoroutine(jumpCoroutine);
            }
            jumpCoroutine = StartCoroutine(JumpCoroutine());
            currentJumpCount++;
        }
    }

    private IEnumerator JumpCoroutine()
    {
        // 점프 채공시간의 절반을 구해준다
        float halfDuration = jumpDuration / 2f;
        float jumpProgress = 0f;


        // 상승
        while (jumpProgress < halfDuration)
        {
            jumpYNum = 1;
            jumpProgress += Time.deltaTime;
            float t = jumpProgress / halfDuration;
            // 부드러운 곡선을 구현
            CurrentJumpY = Mathf.Lerp(0, JumpHeigt, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
        // 하강
        jumpProgress = 0f;
        while (jumpProgress < halfDuration)
        {
            jumpYNum = 2;
            jumpProgress += Time.deltaTime;
            float t = jumpProgress / halfDuration;
            CurrentJumpY = Mathf.Lerp(JumpHeigt, 0, Mathf.SmoothStep(0, 1, t));
            
            yield return null;
        }
        jumpYNum = 0;
        CurrentJumpY = 0;
        currentJumpCount = 0;
        jumpCoroutine = null;


    }

    public float CurrentJump()
    {
        if (jumpYNum == 1)
        {
            return CurrentJumpY;
        }
        else if (jumpYNum == 2)
        {
            return -CurrentJumpY;
        }

        return 0;
    }


    public void RestJumpCount()
    {
        currentJumpCount = 0;
    }

}
