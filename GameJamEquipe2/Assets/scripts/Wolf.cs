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

    protected override void death()
    {
        audioSource.clip = audioDeathHowl;
        audioSource.Play();
        base.death();
    }



}
