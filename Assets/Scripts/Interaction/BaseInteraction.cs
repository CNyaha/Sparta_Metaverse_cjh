using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Compilation;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class BaseInteraction : MonoBehaviour
{
    protected UIManager uiManager;
    public GameObject showText; // ������ ������Ʈ
    public TextMeshProUGUI interectioNameTxt; // �ؽ�Ʈ




    protected abstract InteractionState GetInteractionState();

    public virtual void Init(UIManager uIManager)
    {
        this.uiManager = uIManager;
        showText.SetActive(false);
    }

    public abstract void Interface(); // �� ���� ������ �޼���


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
