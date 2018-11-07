using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropItem : MonoBehaviour
{
    public GameObject tempParent;
    public Transform guide;

    public GameObject items;

    private void Start()
    {
        items.GetComponent<Rigidbody>().useGravity = true;
    }


    /// <summary>
    /// Inherit GvrReticlePointer to use this function
    /// </summary>
    //public override void OnPointerEnter(RaycastResult raycastResultResult, bool isInteractive)
    //{
    //    //Debug.Log("Game Object Name: " + raycastResultResult.gameObject.name + " Gameobject Tag: " + raycastResultResult.gameObject.tag);

    //    if (raycastResultResult.gameObject.CompareTag("Trash"))
    //    {
    //        Debug.Log("You're looking at a trash " + raycastResultResult.gameObject.name);
    //        raycastResultResult.gameObject.GetComponent<Rigidbody>().useGravity = false;
    //        raycastResultResult.gameObject.GetComponent<Rigidbody>().isKinematic = true;
    //        //items = hit.collider.gameObject;
    //        //items.GetComponent<Rigidbody>().useGravity = false;
    //        //items.GetComponent<Rigidbody>().isKinematic = true;
    //        //items.transform.position = guide.transform.position;
    //        ////items.transform.rotation = guide.transform.rotation;
    //        //items.transform.parent = tempParent.transform;
    //    }
    //}



    public void clickObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
                items.GetComponent<Rigidbody>().useGravity = false;
                items.GetComponent<Rigidbody>().isKinematic = true;
                items.transform.position = guide.transform.position;
                //items.transform.rotation = guide.transform.rotation;
                items.transform.parent = tempParent.transform;
            
        }
    }

    public void letGoObject()
    {
        if (Input.GetMouseButtonUp(0))
        {
            items.GetComponent<Rigidbody>().useGravity = true;
            items.GetComponent<Rigidbody>().isKinematic = false;
            items.transform.parent = null;
            items.transform.position = guide.transform.position;
        }
    }
}
