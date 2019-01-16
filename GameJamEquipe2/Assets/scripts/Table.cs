using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{

    public MasterObject objectOnTable;

    public Transform transformPointForObject;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /**Place un object sur la table
     * 
     * @return Si l'object a été placer ou pas
     */
    public virtual void PutObjectOnTable(MasterObject newObjectOnTable)
    {
        if (objectOnTable != null)
        {
            Debug.LogError("object already on table");
            return;
        }

        objectOnTable = newObjectOnTable;
        //objectOnTable.PlaceOnTable(transformPointForObject);
        objectOnTable.transform.position = transformPointForObject.position;
        objectOnTable.SetParent(transformPointForObject);
    }

    /** prend un object de sur la table
     * 
     * @return l'object pris
     */
    public virtual MasterObject PickItemOnTable()
    {

        MasterObject objectToReturn = objectOnTable;
        objectOnTable = null;


        return objectToReturn;
    }

    public bool IsAnyItemOnTable()
    {
        if (objectOnTable != null)
            return true;

        return false;
    }

}
