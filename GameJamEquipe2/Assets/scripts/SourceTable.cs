using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SourceTable : Table
{

    public MasterObject ressourceObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override MasterObject PickItemOnTable()
    {
        if (IsAnyItemOnTable())
        {
            return base.PickItemOnTable();
        }

        return Instantiate(ressourceObject); 

    }

}
