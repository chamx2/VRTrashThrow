using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinIdentity : TrashManager
{
    public BinType binTypeIdentity;


    public BinType GetBinTypeIdentity()
    {
        return this.binTypeIdentity;
    }
    //know trashbin identity
    //check collided identity
    //if same, plus points
    //else minus


    public void OnCollisionEnter(Collision collision)
    {
        TrashType trashIdentity = collision.gameObject.GetComponent<TrashIdentity>().trashTypeIdentity;

        GameObject gameObjectThatCollided = collision.gameObject;

        if (trashIdentity != null)
        {
            switch (binTypeIdentity)
            {
                case BinType.Biodegradable:
                    if (trashIdentity == TrashType.Biodegradable)
                    {
                        CorrectTrash(gameObjectThatCollided);
                    }
                    else
                    {
                        WrongTrash(gameObjectThatCollided);
                    }
                    break;

                case BinType.NonBiodegradable:
                    if (trashIdentity == TrashType.NonBiodegradable)
                    {
                        CorrectTrash(gameObjectThatCollided);
                    }
                    else
                    {
                        WrongTrash(gameObjectThatCollided);
                    }
                    break;

                case BinType.Recyclable:
                    if (trashIdentity == TrashType.Recyclable)
                    {
                        CorrectTrash(gameObjectThatCollided);
                    }
                    else
                    {
                        WrongTrash(gameObjectThatCollided);
                    }
                    break;
            }

        }
    }
}