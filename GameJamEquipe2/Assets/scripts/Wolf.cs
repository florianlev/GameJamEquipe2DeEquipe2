using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wolf : Enemy
{
    // Start is called before the first frame update

    //private float timeBeforeDestruction = 4f;

    public AudioClip audioHowl;
    public AudioClip audioDeathHowl;

    private AudioSource audioSource;
    NavMeshAgent _navMeshAgent;
    //private Animator animator;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = audioHowl;
        audioSource.Play();
        animator = gameObject.GetComponent<Animator>();

       _navMeshAgent = this.GetComponent<NavMeshAgent>();
        Debug.Log(animator);
        animator.SetBool("enMarche", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "zoneLit")
        {
            _navMeshAgent.speed = 0;
            this.gameObject.GetComponent<Animator>().SetBool("enMarche", false);

        }
    }

    void OnTriggerExit(Collider other)
    {
        _navMeshAgent.speed = 3;
        this.gameObject.GetComponent<Animator>().SetBool("enMarche", true);

    }
    public override void Interracted(MasterObject interractedObject)
    {
        base.Interracted(interractedObject);

        if (interractedObject.GetType() == typeof(Pieu))
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
