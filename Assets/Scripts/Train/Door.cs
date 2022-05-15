using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string detectTag = "Player";
    [Space]
    public SpriteFade prompt;
    public Transform targetTransform;

    Transform player;

    private void Update()
    {
        if (Input.GetButtonUp("Vertical") && player) UseDoor(player);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == detectTag)
        {
            player = collision.transform;
            if (prompt) prompt.FadeIn(0.25f);
            //if (OnDoorEnter != null) OnDoorEnter.Invoke(player);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform == player)
        {
            //if (OnDoorExit != null) OnDoorExit.Invoke(player);
            if (prompt) prompt.FadeOut(0.25f);
            player = null;
        }
    }

    public virtual void UseDoor(Transform user) 
    {
        if (targetTransform && user)
            user.position = targetTransform.position;
    }
}
