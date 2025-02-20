using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum MinigameState
{
    Home,
    Flapy
}

public enum InteractionState
{
    Home,
    Minigame
}

public class UIManager : MonoBehaviour
{

    MinigameRoomInteration minigaRoomInteraction;

    private InteractionState itState;
    private MinigameState mgState;

    private FlapyUI flapyUI;



    private void Awake()
    {

        minigaRoomInteraction = GetComponentInChildren<MinigameRoomInteration>(true);
        if (minigaRoomInteraction == null)
        {
            Debug.LogError("minigaRoomIntertion 을 찾지 못함");
        }
        minigaRoomInteraction.Init(this);

        flapyUI = GetComponentInChildren<FlapyUI>(true);
        flapyUI.Init(this);

    }

    public void ChageInteraction(InteractionState state)
    {
        itState = state;
        minigaRoomInteraction.SetActive(itState);
    }



}
