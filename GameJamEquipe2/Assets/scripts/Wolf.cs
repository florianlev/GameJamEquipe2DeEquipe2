using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    // Start is called before the first frame update

    private float timeBeforeDestruction = 4f;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public override void Interracted(MasterObject interractedObject)
    {
        base.Interracted(interractedObject);

        if (interractedObject.GetType() == typeof(Pieu))
        {
            
            StartCoroutine(delaySpawnParticle());

            


        }

    }*/
    /*IEnumerator delaySpawnParticle()
    {
        GameObject particle = Instantiate(particleDeath, transform.position, transform.rotation);
        var emission = particle.GetComponent<ParticleSystem>().emission;
        yield return new WaitForSeconds(3);
        emission.enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(4);
        Destroy(particle);
        death();
    }*/


}
