using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HideOnCollide : SpriteFade
{
    public float fadeTime = 0.25f;
    public bool invert = false;
    [Space]
    public string detectTag = "Player";

    GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == detectTag)
        {
            player = collision.gameObject;
            if (invert) FadeIn(fadeTime);
            else FadeOut(fadeTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player = null;
            if (invert) FadeOut(fadeTime);
            else FadeIn(fadeTime);
        }
    }
}
