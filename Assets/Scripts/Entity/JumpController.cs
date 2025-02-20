using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    // ���� �� �̵��� �� �ְ� �� ����. �׷����� �ϴ� �����ϴ� y���� ���� ������϶� y+ �ϰ����� �� y-�� �غ���

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
    // ������ �� �߰����� y��
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
            jumpYNum = 1;
            jumpProgress += Time.deltaTime;
            float t = jumpProgress / halfDuration;
            // �ε巯�� ��� ����
            CurrentJumpY = Mathf.Lerp(0, JumpHeigt, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
        // �ϰ�
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
