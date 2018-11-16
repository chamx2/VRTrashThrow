using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerTagTarget : GvrReticlePointer
{
    public GameObject guide;


    public override void OnPointerHover(RaycastResult raycastResultResult, bool isInteractive)
    {
        base.OnPointerHover(raycastResultResult, isInteractive);
        if(raycastResultResult.gameObject.name == "cola_can")
        {
            Debug.Log(raycastResultResult.gameObject.tag);
        }
        
    }
    /// <summary>
    /// Inherit GvrReticlePointer to use this function
    /// </summary>
    //public override void OnPointerEnter(RaycastResult raycastResultResult, bool isInteractive)
    //{
    //    Debug.Log("Game Object Name: " + raycastResultResult.gameObject.name + " Gameobject Tag: " + raycastResultResult.gameObject.tag);

    //    if (raycastResultResult.gameObject.CompareTag("Recyclable"))
    //    {
    //        Debug.Log("You're looking at a trash " + raycastResultResult.gameObject.name);
    //        raycastResultResult.gameObject.GetComponent<Rigidbody>().useGravity = false;
    //        raycastResultResult.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //        items = raycastResultResult.gameObject;
    //        items.GetComponent<Rigidbody>().useGravity = false;
    //        items.GetComponent<Rigidbody>().isKinematic = true;
    //        items.transform.position = guide.transform.position;
    //        items.transform.rotation = guide.transform.rotation;
    //        items.transform.parent = tempParent.transform;
    //    }
    //}

    // Update is called once per frame
    void Update ()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(Vector3.zero, Vector3.forward, out hit))
        {
            Debug.Log(hit.transform.gameObject);
            if(hit.collider.CompareTag("Biodegradable"))
            {

               guide = hit.transform.gameObject; 
            }
        }

	}
}
