using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class DragDropItem : MonoBehaviour
{


     void OnMouseDown()
    {
        Debug.Log("Dragging Object");
        GameManager.Instance.SetCurrentTrashItem(this.gameObject);
        GameManager.Instance.clickObject();
    }
    void OnMouseDrag()
    {
        //Debug.Log("Dragging Object");
        //SetCurrentTrashItem(this.gameObject);
        //clickObject();
    }

    void OnMouseUp()
    {
        Debug.Log("Letting Go of the object");
        GameManager.Instance.letGoObject();
    }


}



//public void clickObject()
//{
//    if (Input.GetMouseButtonUp(0))
//    {
//        trashItem.GetComponent<Rigidbody>().useGravity = false;
//        trashItem.GetComponent<Rigidbody>().isKinematic = true;
//        trashItem.transform.position = guide.transform.position;
//        //items.transform.rotation = guide.transform.rotation;
//        trashItem.transform.parent = tempParent.transform;

//    }
//}

//public void letGoObject()
//{
//    if (Input.GetMouseButtonUp(0))
//    {
//        trashItem.GetComponent<Rigidbody>().useGravity = true;
//        trashItem.GetComponent<Rigidbody>().isKinematic = false;
//        trashItem.transform.parent = null;
//        //items.transform.rotation = guide.transform.rotation;
//        trashItem.transform.position = guide.transform.position;
//    }
//}