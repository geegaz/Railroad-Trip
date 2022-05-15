using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerAnimation : MonoBehaviour
{
    public SpriteRenderer sprite;

    PlayerMovement movement;
    Animator animator;

    AnimatorStateInfo currentState;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentState = animator.GetCurrentAnimatorStateInfo(animator.GetLayerIndex("Base Layer"));
        float speedAbs = Mathf.Abs(movement.speed);

        if (movement.dir > 0)
            sprite.flipX = false;
        else if (movement.dir < 0)
            sprite.flipX = true;

        float momentum = speedAbs * movement.dir - movement.speed;

        animator.SetFloat("Speed", speedAbs);
        animator.SetFloat("Momentum", Mathf.Abs(momentum));
        animator.SetBool("Running", movement.running);
    }
}
