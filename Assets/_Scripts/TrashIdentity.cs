using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
public class TrashIdentity : TrashManager
{

    public TrashType trashTypeIdentity;

    public TrashType GetTrashTypeIdentity()
    {
        return this.trashTypeIdentity;
    }

}

