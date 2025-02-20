using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum MinigameState
{
    Null,
    Dungeon,
    TheStack
}

public enum InteractionState
{
    Null,
    Minigame
}

public class UIManager : MonoBehaviour
{

    MinigameRoomInteration minigaRoomInteraction;

    private InteractionState itState;
    private MinigameState mgState;



    private void Awake()
    {

        minigaRoomInteraction = GetComponentInChildren<MinigameRoomInteration>(true);
        if (minigaRoomInteraction == null)
        {
            Debug.LogError("minigaRoomIntertion 을 찾지 못함");
        }
        minigaRoomInteraction.Init(this);


    }

    public void ChageInteraction(InteractionState state)
    {
        itState = state;
        minigaRoomInteraction.SetActive(itState);
    }



}
