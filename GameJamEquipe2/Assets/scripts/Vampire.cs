using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Vampire : Enemy
{
    // Start is called before the first frame update




    NavMeshAgent _navMeshAgent;


    private AudioSource audioSource;
    public AudioClip laughtVampire;

    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
        this.gameObject.GetComponent<Animator>().SetBool("isWalk", true);
        audioSource = GetComponentInChildren<AudioSource>();
        audioSource.PlayOneShot(laughtVampire);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "zoneLit")
        {
            Debug.Log("test");
            _navMeshAgent.speed = 0;
            this.gameObject.GetComponent<Animator>().SetBool("isWalk", false);

        }
    }

    void OnTriggerExit(Collider other)
    {
        _navMeshAgent.speed = 3;
        this.gameObject.GetComponent<Animator>().SetBool("isWalk", true);

    }

    public override void Interracted(MasterObject interractedObject)
    {
        base.Interracted(interractedObject);

        if (interractedObject.GetType() == typeof(Garlic))
        {

            StartCoroutine(delaySpawnParticle());

        }

    }
    public override void deathBomb()
    {
        StartCoroutine(delaySpawnParticle());

    }
    IEnumerator delaySpawnParticle()
    {
        isDead = true;
        GameObject particle = Instantiate(particleDeath, transform.position, transform.rotation);
        var emission = particle.GetComponent<ParticleSystem>().emission;

        this.gameObject.GetComponent<Animator>().SetTrigger("death");

        this.gameObject.GetComponent<CapsuleCollider>().enabled = false;

        yield return new WaitForSeconds(timeBeforeHiddenMesh);
        this.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().enabled = false;
        emission.enabled = false;

        yield return new WaitForSeconds(timeBeforeDestroyObject);
        Destroy(particle);
        death();


    }

}
