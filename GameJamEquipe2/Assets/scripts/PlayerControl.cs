using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Vector3 movementVector;

    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";
    public string takeCtrl = "take_P1";


    private CharacterController characterController;

    public float movementSpeed = 15;

    private float gravity = 40;


    public Table tableInteractable;
    public MasterObject objectInHand;
    public Transform transformObjectInHand;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {

        //if (Input.GetButtonDown(takeCtrl))

        //Mouvement du perso

        movementVector.x = Input.GetAxis(horizontalCtrl) * movementSpeed;
        movementVector.z = Input.GetAxis(verticalCtrl) * movementSpeed;


        movementVector.y -= gravity * Time.deltaTime;

        characterController.Move(movementVector * Time.deltaTime);


        //Action

        if (Input.GetButtonDown(takeCtrl))
        {
            if (tableInteractable)
            {
                /**put object from hand on the table*/
                if (objectInHand && tableInteractable.IsAnyItemOnTable() == false)
                {
                    PutObjectOnTable();
                }
                /**pickup object from table*/
                else if (objectInHand == null)// && tableInteractable.IsAnyItemOnTable() == true)
                {
                    PickupObjectFromTable();
                }

                /**pickup object from source table*/
                /*else if (objectInHand == null && tableInteractable.GetType() == typeof(SourceTable))
                {
                    SourceTable copyTable = (SourceTable)tableInteractable;
                    objectInHand = copyTable.PickRessourceObject();
                }*/
            }
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Table>())
        {
            tableInteractable = collision.gameObject.GetComponent<Table>();
            //tableInteractable.EnterInteractable();
            Debug.Log("enter collision");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Table>())
        {
            if (tableInteractable)
            {
                if (tableInteractable.gameObject == collision.gameObject)
                {
                    tableInteractable = null;
                    //collision.gameObject.GetComponent<Table>().ExitInteractable();
                }
            }
        }
    }


    private void PutObjectOnTable()
    {
        if (tableInteractable == null || objectInHand == null)
        {
            Debug.LogError("PlayerMovement (PutObjectOnTable) : no table or no object to place");
            return;
        }
        tableInteractable.PutObjectOnTable(objectInHand);
        objectInHand = null;
    }

    private void PickupObjectFromTable()
    {
        if (tableInteractable == null)
        {
            Debug.LogError("PlayerMovement (PickupObjectFromTable) : no table in range)");
            return;
        }
        objectInHand = tableInteractable.PickItemOnTable();
        objectInHand.transform.position = transformObjectInHand.position;
        objectInHand.transform.parent = transformObjectInHand;
    }



}
