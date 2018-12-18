using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUp : GvrReticlePointer
{
    
    public override void OnPointerEnter(RaycastResult raycastResultResult, bool isInteractive)
    {
        base.OnPointerEnter(raycastResultResult, isInteractive);

        if (raycastResultResult.gameObject.CompareTag("Trash"))
        {
            Debug.Log(raycastResultResult.gameObject.tag);
        }

    }


}
