using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



public class DragDropItem : EventTrigger
{


    // void OnMouseDown()
    //{
    //    //Debug.Log("Dragging Object");

    //}

    //void OnMouseUp()
    //{
    //    GameManager.Instance.letGoObject();
    //}

    public override void OnPointerEnter(PointerEventData eventData)
    {
        GameManager.Instance.ChangeReticleText(this.gameObject);
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
        GameManager.Instance.ResetReticleText();
    }

    public override void OnPointerDown(PointerEventData data)
    {
        //Debug.Log("OnPointerDown called.");
        GameManager.Instance.SetCurrentTrashItem(this.gameObject);
        GameManager.Instance.clickObject();

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("OnPointerUp called.");
        GameManager.Instance.letGoObject();
        //base.OnPointerUp(eventData);
    }

    //public void UpItem()
    //{
    //    //Debug.Log("Letting Go of the object");
    //    GameManager.Instance.SetCurrentTrashItem(this.gameObject);
    //    GameManager.Instance.clickObject();
    //}

    //public void DownItem()
    //{
    //    GameManager.Instance.letGoObject();
    //}

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