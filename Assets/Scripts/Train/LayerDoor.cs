using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerDoor : Door
{
    public string targetLayer;

    public override void UseDoor(Transform user)
    {
        base.UseDoor(user);
        
        int layerId = LayerMask.NameToLayer(targetLayer);
        if (layerId != -1 && layerId != user.gameObject.layer)
        {
            user.gameObject.layer = layerId;
            foreach (SpriteRenderer sprite in user.GetComponentsInChildren<SpriteRenderer>())
            {
                sprite.sortingLayerName = targetLayer;
            }
        }
    }
}
