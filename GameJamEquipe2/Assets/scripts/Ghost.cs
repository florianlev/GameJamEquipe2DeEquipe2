using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Enemy
{
    // Start is called before the first frame update


    public Transform destination;
    private Vector3 lookDirection;

    private AudioSource audioSource;
    public AudioClip ghostHowl;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = ghostHowl;

        audioSource.Play();
    }


    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime;
        Vector3 relativePos = destination.position - transform.position;

        transform.position = Vector3.MoveTowards(transform.position, destination.position, step);
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);

        transform.rotation = rotation;

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

    IEnumerator delaySpawnParticle()
    {
        isDead = true;
        GameObject particle = Instantiate(particleDeath, transform.position, transform.rotation);
        var emission = particle.GetComponent<ParticleSystem>().emission;


        this.gameObject.GetComponent<Animator>().SetTrigger("dead");

        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(timeBeforeHiddenMesh);
        emission.enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(timeBeforeDestroyObject);
        Destroy(particle);
        death();


    }


}
