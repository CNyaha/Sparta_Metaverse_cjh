using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
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
    public float CurrentJumpOffset { get; private set; }


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
            jumpProgress += Time.deltaTime;
            float t = jumpProgress / halfDuration;
            // 부드러운 곡선을 구현
            float offSet = Mathf.Lerp(0, jumpHeight, Mathf.SmoothStep(0, 1, t));
            SetJumpOffset(offSet);
            yield return null;
        }
        // 하강
        jumpProgress = 0f;
        while (jumpProgress < halfDuration)
        {
            jumpProgress += Time.deltaTime;
            float t = jumpProgress / halfDuration;
            float offSet = Mathf.Lerp(jumpHeight, 0, Mathf.SmoothStep(0, 1, t));
            SetJumpOffset(offSet);
            yield return null;
        }

        SetJumpOffset(0);
        jumpCoroutine = null;


    }

    private void SetJumpOffset(float offset)
    {
        Vector3 pos = position;
        pos.y += offset;
        transform.localPosition = pos;
    }

    public void RestJumpCount()
    {
        currentJumpCount = 0;
    }

}
