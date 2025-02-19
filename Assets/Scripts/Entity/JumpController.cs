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
    // ������ �ִ� Ƚ��
    [Range(1, 3)][SerializeField] private int maxJumpCount = 1;
    public int MaxJumpCount
    {
        get => maxJumpCount;
        set => maxJumpCount = Mathf.Clamp(value, 1, 3);
    }

    private int currentJumpCount = 0; //������ ���� Ƚ��
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
            // ���� �� ����  ������ ��ġ�� ������ġ�� ����
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
        // ���� ä���ð��� ������ �����ش�
        float halfDuration = jumpDuration / 2f;
        float jumpProgress = 0f;

        // ���
        while (jumpProgress < halfDuration)
        {
            jumpProgress += Time.deltaTime;
            float t = jumpProgress / halfDuration;
            // �ε巯�� ��� ����
            float offSet = Mathf.Lerp(0, jumpHeight, Mathf.SmoothStep(0, 1, t));
            SetJumpOffset(offSet);
            yield return null;
        }
        // �ϰ�
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
