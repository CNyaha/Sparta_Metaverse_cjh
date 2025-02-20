using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseInteraction : MonoBehaviour
{
    protected UIManager uiManager;
    public GameObject showText; // 보여줄 오브젝트
    public TextMeshProUGUI interectioNameTxt; // 텍스트




    protected abstract InteractionState GetInteractionState();

    public virtual void Init(UIManager uIManager)
    {
        this.uiManager = uIManager;
        showText.SetActive(false);
    }

    public abstract void Interface(); // 각 방을 구현할 메서드


    public void SetActive(InteractionState state)
    {
        this.gameObject.SetActive(GetInteractionState() == state);
    }

    public void InteractionTextSetActive(bool isActive)
    {
        showText.SetActive(isActive);
        
    }

    public void InterectionText(string text)
    {
        interectioNameTxt.text = text;
    }

    public void SetTextPosition(Vector3 position)
    {
        interectioNameTxt.transform.position = position;
    }


}
