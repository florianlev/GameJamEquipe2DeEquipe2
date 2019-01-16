using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    // Start is called before the first frame update


    public Transform destination;


    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
    }

    public override void Interracted(MasterObject interractedObject)
    {
        base.Interracted(interractedObject);

        Debug.Log(interractedObject.GetType());

        if (interractedObject.GetType() == typeof(Cross))
        {
            //death();
        }

    }
}
