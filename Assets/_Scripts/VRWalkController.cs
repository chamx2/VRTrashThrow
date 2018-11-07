using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class VRWalkController : MonoBehaviour
{
    public Transform vrCamera;

    public float moveSpeed = 50.0f;

    private CharacterController cc;

    private RaycastHit hit;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
       
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * moveSpeed * Time.deltaTime);

                //if(Physics.Raycast(transform.position, -Vector3.up, out hit) && hit.game = GameObject.FindGameObjectsWithTag("Trash"))
                //{
                //     print("Found an object - distance: " + hit.distance);
                //}
        }
    }
}
