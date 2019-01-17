using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Vector3 movementVector;
    private Vector3 lookDirection;

    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";
    public string takeCtrl = "Take_P1";
    public string interractionCtrl = "Action_P1";
    public string dashCtrl = "Dash_P1";

    private Animator animator;


    private CharacterController characterController;

    public float movementSpeed = 15;
    public float boostFromDash = 5;
    public float boostTime = 0.5f;
    public float currentCooldown = 0;
    public float dashCooldownTime = 1;
    private float initialSpeed;
    private float gravity = 40;
    private bool isDashing = false;



    public Table tableInteractable;
    public MasterObject objectInHand;
    public Transform transformObjectInHand;

    public MasterObject objectOnFloorInteractable;

    public Collider interractionCollider;

    public List<GameObject> gameObjectsInterractable;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        initialSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown(dashCtrl))
            Debug.Log("DAHSHS");*/


        //if (Input.GetButtonDown(takeCtrl))

        //CoolDown du dash
        if(currentCooldown < dashCooldownTime)
        {
            
            currentCooldown += Time.deltaTime;
            if (currentCooldown > dashCooldownTime)
                currentCooldown = dashCooldownTime;
        }


        //Dash
        if ((Input.GetButtonDown("Dash_P1") || Input.GetAxis("Dash_P1") > 0) && currentCooldown == dashCooldownTime)
        {
            isDashing = true;
            currentCooldown = 0;
            movementSpeed += boostFromDash;
            StartCoroutine(Dash(boostTime));

        }

        //Mouvement du perso

        float horizontalInput = Input.GetAxis(horizontalCtrl);
        float verticalInput = Input.GetAxis(verticalCtrl);

        movementVector.x = horizontalInput;// * movementSpeed;

        movementVector.z = verticalInput; //* movementSpeed;
        movementVector.y = 0;


        


        if (movementVector.magnitude > 1)
            movementVector.Normalize();

       movementVector.y -= gravity * Time.deltaTime;


       characterController.Move(movementVector * Time.deltaTime * movementSpeed);

        if (horizontalInput != 0 || verticalInput != 0)
        {
            Debug.Log(animator.GetBool("isWalk"));

            animator.SetBool("isWalk", true);
         

        }
        else
        {
            animator.SetBool("isWalk", false);

        }

        //rotation


        if (characterController.velocity.x != 0)
        {
            lookDirection.x = characterController.velocity.x;    
        }

        if (characterController.velocity.z != 0)
            lookDirection.z = characterController.velocity.z;

        if (lookDirection.x != 0 || lookDirection.z != 0)
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDirection), 0.3f);


        //Action
        //take object
        if (Input.GetButtonDown(takeCtrl))
        {
            /**put object from hand on the table*/
            if (objectInHand && tableInteractable && tableInteractable.IsAnyItemOnTable() == false)
            {
                PutObjectOnTable();
            }
            /**pickup object from table*/
            else if (objectInHand == null && tableInteractable)// && tableInteractable.IsAnyItemOnTable() == true)
            {

                PickupObjectFromTable();
            }

            /**pickup object from source table*/
            /*else if (objectInHand == null && tableInteractable.GetType() == typeof(SourceTable))
            {
                SourceTable copyTable = (SourceTable)tableInteractable;
                objectInHand = copyTable.PickRessourceObject();
            }*/

            //drop floor
            else if (objectInHand != null && tableInteractable == null)
            {

                PutObjectFromFloor();
            }
            else if (objectInHand == null && tableInteractable == null && objectOnFloorInteractable)
            {
                PickupObjectFromFloor();
            }
        }

        //use object
        if (Input.GetButtonDown(interractionCtrl))
        {
            Debug.Log("use");
            foreach (GameObject gameObject in gameObjectsInterractable)
            {
                if (gameObject == null)
                {
                    gameObjectsInterractable.Remove(gameObject);
                }
                else
                {
                    if (gameObject.GetComponent<Enemy>())
                    {
                        animator.SetTrigger("attack");
                        Debug.Log("object have Enemy");
                        //Debug.Log(objectInHand.GetType());
                        GameObject enemyCopy = gameObject;
                        gameObject.GetComponent<Enemy>().Interracted(objectInHand);
                        objectInHand.Interraction(enemyCopy.GetComponent<Enemy>());
                    }
                }
            }
        }

    }

    private void PutObjectFromFloor()
    {
        animator.SetLayerWeight(1, 0);
        objectInHand.SetParent(null);
        objectInHand.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward;
        objectInHand = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("enter collision with " + collision.gameObject.name);

        if (collision.gameObject.GetComponent<Table>())
        {
            tableInteractable = collision.gameObject.GetComponent<Table>();
            //tableInteractable.EnterInteractable();
        }

        if (collision.gameObject.GetComponent<MasterObject>())
        {
            objectOnFloorInteractable = collision.gameObject.GetComponent<MasterObject>();
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

        if (collision.gameObject.GetComponent<MasterObject>())
        {
            if (objectOnFloorInteractable)
            {
                if (objectOnFloorInteractable.gameObject == collision.gameObject)
                {
                    objectOnFloorInteractable = null;
                    //collision.gameObject.GetComponent<Table>().ExitInteractable();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        gameObjectsInterractable.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        
        int i = 0;
        foreach (GameObject gameObject in gameObjectsInterractable)
        {
            if (other.gameObject == gameObject)
            {
                gameObjectsInterractable.Remove(gameObject);
            }
            i++;
        }
        
        //gameObjectsInterractable.Remove(gameObject);

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

        animator.SetLayerWeight(1, 0);
    }

    private void PickupObjectFromTable()
    {
        if (tableInteractable == null)
        {
            Debug.LogError("PlayerMovement (PickupObjectFromTable) : no table in range)");
            return;
        }
        animator.SetLayerWeight(1, 1);
        animator.SetTrigger("grab");

        animator.SetInteger("compteurTake", 0);

        objectInHand = tableInteractable.PickItemOnTable();
        objectInHand.transform.position = transformObjectInHand.position;
        objectInHand.transform.rotation = transformObjectInHand.rotation;
        objectInHand.SetParent(transformObjectInHand);
        //objectInHand.transform.parent = transformObjectInHand;
    }

    private void PickupObjectFromFloor()
    {

        animator.SetLayerWeight(1, 1);
        animator.SetTrigger("grab");


        objectInHand = objectOnFloorInteractable;
        objectInHand.transform.position = transformObjectInHand.position;
        objectInHand.transform.rotation = transformObjectInHand.rotation;
        objectInHand.SetParent(transformObjectInHand);
        objectOnFloorInteractable = null;
    }

    private IEnumerator Dash(float a_Delay)
    {
        animator.SetBool("isRun", true);

        yield return new WaitForSeconds(a_Delay);
        movementSpeed = initialSpeed;

        if (movementSpeed < initialSpeed)
            movementSpeed = initialSpeed;
        /*if(movementSpeed > initialSpeed)
            StartCoroutine(Dash(0.25f));*/

        animator.SetBool("isRun", false);



    }



}
