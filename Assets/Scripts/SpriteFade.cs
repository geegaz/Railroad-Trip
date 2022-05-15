using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFade : MonoBehaviour
{
    public bool fadeChildren = true;
    public float opacity = 1f;
    float speed;

    SpriteRenderer renderer;
    SpriteRenderer[] renderers;


    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        opacity = Mathf.Clamp01(opacity + speed * Time.deltaTime);

        if (fadeChildren) SetSpriteOpacity(renderers, opacity);
        else SetSpriteOpacity(renderer, opacity);
    }

    public void Fade(float to, float time, bool relativeTime)
    {
        if (time <= 0) opacity = to;
        else
            if (relativeTime)
                speed = (to - opacity) / time;
            else
                speed = Mathf.Sign(to - opacity) / time;
    }

    public void FadeIn(float time = 0.5f, bool relativeTime = false)
    {
        Fade(1f, time, relativeTime);
    }

    public void FadeOut(float time = 0.5f, bool relativeTime = false)
    {
        Fade(0f, time, relativeTime);
    }

    private void SetSpriteOpacity(SpriteRenderer sprite, float opacity)
    {
        Color spriteColor = sprite.color;
        spriteColor.a = opacity;
        sprite.color = spriteColor;
    }
    private void SetSpriteOpacity(SpriteRenderer[] sprites, float opacity)
    {
        foreach (SpriteRenderer sprite in sprites) SetSpriteOpacity(sprite, opacity);
    }
}
