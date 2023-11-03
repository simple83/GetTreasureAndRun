using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5.0f; // 카메라 이동 속도
    private Rigidbody2D cameraRigidbody;

    private void Start()
    {
        cameraRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
    void LateUpdate()
    {
        //Vector2 initialVelocity = new Vector2(PlayerController.initialSpeed, cameraRigidbody.velocity.y);
        //cameraRigidbody.velocity = initialVelocity;
    }
}

