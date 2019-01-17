using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wolf : Enemy
{
    // Start is called before the first frame update

    private float timeBeforeDestruction = 4f;

    public AudioClip audioHowl;
    public AudioClip audioDeathHowl;

    private AudioSource audioSource;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioHowl;
        audioSource.Play();
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
            
            StartCoroutine(delaySpawnParticle());

        }

    }

    IEnumerator delaySpawnParticle()
    {
        isDead = true;
        GameObject particle = Instantiate(particleDeath, transform.position, transform.rotation);
        var emission = particle.GetComponent<ParticleSystem>().emission;


        //this.gameObject.GetComponent<Animator>().SetTrigger("dead");

        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(timeBeforeHiddenMesh);
        emission.enabled = false;
        this.gameObject.GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(timeBeforeDestroyObject);
        Destroy(particle);
        death();


    }

    protected override void death()
    {
        audioSource.clip = audioDeathHowl;
        audioSource.Play();
        base.death();
    }



}
