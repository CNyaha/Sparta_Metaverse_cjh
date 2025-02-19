using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    float OffsetZ;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
            return;

        OffsetZ = transform.position.z - target.position.z;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 cameraPos = target.position;
        cameraPos.z = target.transform.position.z;
        transform.position = cameraPos;
    }
}
