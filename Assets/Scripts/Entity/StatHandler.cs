using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class StatHandler : MonoBehaviour
{
    [Range(1f, 100f)][SerializeField] private float health = 10f;
    public float Health
    {
        get => health;
        set => health = Mathf.Clamp(value, 0f, 100f);
    }

    [Range(1f, 20f)][SerializeField] private float speed = 3;

    public float Speed
    {
        get => speed;
        set => speed = Mathf.Clamp(value, 0f, 20f);
    }

    public int gold = 0;

    public float posX = 0;
    public float posY = 0;




}
