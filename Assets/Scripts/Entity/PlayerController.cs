using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    // 카메라
    private Camera mainCamera;

    protected override void Awake()
    {
        base.Awake();
        mainCamera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        movementDirection = new Vector2(horizontal, vertical).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = mainCamera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }

    }

    protected override void OnInteract()
    {
        Debug.Log("플레이어 상호작용!");
    }

    protected override void Update()
    {
        base.Update();

        if (mainCamera != null)
        {
            Vector3 cameraPos = transform.position;
            cameraPos.z = mainCamera.transform.position.z;
            mainCamera.transform.position = cameraPos;
        }

    }

}
