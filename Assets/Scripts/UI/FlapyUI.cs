using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlapyUI : MinigameUI
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button exitButton;

    public override void Init(UIManager uIManager)
    {
        base.Init(uIManager);

        startButton.onClick.AddListener(OnClickStartButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }

    public void OnClickStartButton()
    {
        Debug.Log("���� Ŭ��");
        SceneManager.LoadScene("MiniFlapy");
    }

    public void OnClickExitButton()
    {

    }

    protected override MinigameState GetMinigameState()
    {
        return MinigameState.Flapy;
    }

    

}
