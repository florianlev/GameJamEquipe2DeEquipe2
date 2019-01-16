using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    // Start is called before the first frame update


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Interracted(MasterObject interractedObject)
    {
        base.Interracted(interractedObject);

        if (interractedObject.GetType() == typeof(Pieu))
        {
            death();
        }

    }
}
