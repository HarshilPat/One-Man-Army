using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothTime;
    // public Vector2 maxPos;
    // public Vector2 minPos;

    // Update is called once per frame
    
    void Update()
    {
        if (target) {
            Vector3 positionTarget = new Vector3(target.position.x, target.position.y, transform.position.z);
            // positionTarget.x = Mathf.Clamp(positionTarget.x, minPos.x, maxPos.x);
            // positionTarget.y = Mathf.Clamp(positionTarget.y, minPos.y, maxPos.y);
            transform.position = Vector3.Lerp(transform.position, positionTarget, smoothTime);
        }
    }
}
