using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform targetTransform;
    public float smoothTime = 0.2f;

    Vector3 velocity;
    Vector3 targetPosition;

    private void Update()
    {
        if (targetTransform)
        {
            targetPosition = new Vector3(
                targetTransform.position.x,
                targetTransform.position.y,
                transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
