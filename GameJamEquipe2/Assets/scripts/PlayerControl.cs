using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Vector3 movementVector;

    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";

    private CharacterController characterController;

    public float movementSpeed = 15;

    private float gravity = 40;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        //Mouvement du perso

        movementVector.x = Input.GetAxis(horizontalCtrl) * movementSpeed;
        movementVector.z = Input.GetAxis(verticalCtrl) * movementSpeed;


        movementVector.y -= gravity * Time.deltaTime;

        characterController.Move(movementVector * Time.deltaTime);

    }
}
