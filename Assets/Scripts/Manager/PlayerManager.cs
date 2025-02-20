using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    StatHandler statHandler;

    #region Singleton

    private static PlayerManager instance = null;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        statHandler = GetComponent<StatHandler>();
    }

    #endregion


    public Vector3 GetPlayerPos()
    {
        return new Vector3(statHandler.posX, statHandler.posY);
    }

    public void SetPlayerPos(float _posX, float _posY)
    {
        statHandler.posX = _posX;
        statHandler.posY = _posY;
    }

}
