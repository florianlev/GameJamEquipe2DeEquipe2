using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    private Vector3 movementVector;

    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";
    public string takeCtrl = "Take_P1";
    public string interractionCtrl = "Action_P1";
    public string dashCtrl = "Dash_P1";



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

    public Collider interractionCollider;

    public List<GameObject> gameObjectsInterractable;

    // Start is called before the first frame update
    void Start()
    {
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
            StartCoroutine(Dash(0.10f));
        }
        //Mouvement du perso
        movementVector.x = Input.GetAxis(horizontalCtrl);// * movementSpeed;
        movementVector.z = Input.GetAxis(verticalCtrl); //* movementSpeed;
        movementVector.y = 0;


        if (movementVector.magnitude > 1)
            movementVector.Normalize();

       // movementVector.y -= gravity * Time.deltaTime;


        characterController.Move(movementVector * Time.deltaTime * movementSpeed);

        //rotation
        transform.rotation = Quaternion.LookRotation(new Vector3(movementVector.x, 0, movementVector.z));


        //Action
        //take object
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


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("enter collision with " + collision.gameObject.name);

        if (collision.gameObject.GetComponent<Table>())
        {
            tableInteractable = collision.gameObject.GetComponent<Table>();
            //tableInteractable.EnterInteractable();
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
        objectInHand.transform.rotation = transformObjectInHand.rotation;
        objectInHand.transform.parent = transformObjectInHand;
    }

    private IEnumerator Dash(float a_Delay)
    {
        yield return new WaitForSeconds(a_Delay);
        movementSpeed = movementSpeed / 1.5f;

        if (movementSpeed < initialSpeed)
            movementSpeed = initialSpeed;
        if(movementSpeed > initialSpeed)
            StartCoroutine(Dash(0.25f));


    }



}
