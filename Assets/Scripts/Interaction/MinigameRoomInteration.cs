using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameRoomInteration : BaseInteraction
{
    public MinigameRoomInteration parentCollider;


    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);
    }

    public override void Interface()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InterectionText("F : MiniGame");
            InteractionTextSetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            InteractionTextSetActive(false);
        }
    }

    protected override InteractionState GetInteractionState()
    {
        return InteractionState.Minigame;
    }

}
