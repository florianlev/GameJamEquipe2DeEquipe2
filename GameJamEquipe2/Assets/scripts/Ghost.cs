using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    // Start is called before the first frame update


    public Transform destination;
    private Vector3 lookDirection;


    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(destination.position), 0.3f);

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "zoneLit")
        {

            speed = 0;
        }
    }


    public override void Interracted(MasterObject interractedObject)
    {
        base.Interracted(interractedObject);

        if (interractedObject.GetType() == typeof(Cross))
        {

            StartCoroutine(delaySpawnParticle());

        }

    }


}
