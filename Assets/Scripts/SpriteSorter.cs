using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSorter : MonoBehaviour
{
    public float layerDepth = 0.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        SortSprites(true);
    }

    public void SortSprites(bool flatten = false)
    {
        Vector3 local_pos;
        Vector3 world_pos;
        SpriteRenderer[] sprites = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            local_pos = sprite.transform.localPosition;
            world_pos = sprite.transform.position;
            sprite.sortingOrder = -(int)(world_pos.z / layerDepth);
            if (flatten)
            {
                local_pos.z = 0;
                sprite.transform.localPosition = local_pos;
            }
        }
    }
}
