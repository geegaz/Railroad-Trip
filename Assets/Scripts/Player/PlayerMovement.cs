using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f; // m/s
    public float runSpeed = 8f; // m/s
    public float acceleration = 10f; // m/s/s
    [Space]
    public float snapMargin = 0f;
    public float groundAngle = 45f;

    [HideInInspector] public bool       onGround = false;
    [HideInInspector] public bool       running = false;
    [HideInInspector] public float      dir = 0f;
    [HideInInspector] public float      speed = 0f;
    [HideInInspector] public Vector2    velocity;
    [HideInInspector] public Vector2    groundNormal;

    Rigidbody2D rigidbody;
    Collider2D collider;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    private void FixedUpdate()
    {
        velocity = rigidbody.velocity;

        //------------ Velocity ------------//
        dir = Input.GetAxis("Horizontal");
        running = Input.GetButton("Fire3");

        float targetSpeed;
        if (running) targetSpeed = dir * runSpeed;
        else targetSpeed = dir * walkSpeed;

        if (running || Mathf.Abs(speed) > walkSpeed)
            speed += acceleration * Time.deltaTime * Mathf.Sign(targetSpeed - speed);
        else
            speed = targetSpeed;

        velocity.x = speed;

        //------------ Ground ------------//
        onGround = false;
        RaycastHit2D[] hit = new RaycastHit2D[1];
        if (collider.Cast(Vector2.down * snapMargin, hit) > 0)
        {
            groundNormal = hit[0].normal;
            onGround = Vector2.Angle(groundNormal, Vector2.up) <= groundAngle;
            //if (onGround && snapMargin > 0)
            //{
            //    transform.position += Vector3.down * hit[0].distance;
            //    velocity.y = 0;
            //}
        }

        rigidbody.velocity = velocity;
    }
}
