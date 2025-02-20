using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameUI : MonoBehaviour
{
    FlapyUI flapyUI;

    MinigameState currentState;

    protected UIManager uiManager;

    public virtual void Init(UIManager uIManager)
    {
        this.uiManager = uIManager;
    }

    private void Awake()
    {
        flapyUI = GetComponentInChildren<FlapyUI>(true);

        ChangeState(MinigameState.Home);
    }


    public void SetFlapy()
    {
        ChangeState(MinigameState.Flapy);
    }

    public void ChangeState(MinigameState state)
    {
        currentState = state;
    }

}
