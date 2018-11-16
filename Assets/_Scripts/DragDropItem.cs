using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropItem : GameManager
{
   
    public GameObject items;

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
            //items.transform.rotation = guide.transform.rotation;
            items.transform.position = guide.transform.position;
        }
    }
}
