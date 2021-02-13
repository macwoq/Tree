using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    CharacterController character;

    [Header("PlayerWalk")]
    public float walkSpeed = 5f;    
    Vector3 moveInput;

    [Header("PlayerLook")]
    public float lookSpeed = 5f;
    public bool invertY;
    public bool invertX;
    Transform cameraTransform;
    Tree tree;


    

    
    

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
        tree = FindObjectOfType<Tree>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Cutting();
        }
       

       

        Walking();
        LookingAround();
        
    }

    private void Cutting()
    {
        
        if (tree.inRange)
        {
            print("tree in range");
            tree.Cut();
        }
        else
        {

            print("tree out of range");
        }
    }

    private void LookingAround()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * lookSpeed;

        if (invertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }



        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

        cameraTransform.rotation = Quaternion.Euler(cameraTransform.rotation.eulerAngles + new Vector3(mouseInput.y,0,0));
    }

    private void Walking()
    {
        //moveInput.x = Input.GetAxis("Horizontal") * walkSpeed;
        //moveInput.z = Input.GetAxis("Vertical") * walkSpeed;

        Vector3 vertivalMove = transform.forward * Input.GetAxis("Vertical");
        moveInput = vertivalMove * walkSpeed * Time.deltaTime;


        character.Move(moveInput);
    }
}
