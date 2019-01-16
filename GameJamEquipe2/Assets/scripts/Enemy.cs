using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public int speed;
    public float power;

    private StressManager stressManager;
    GameObject stressManagerObject;
    public GameObject particleDeath;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerStay(Collider collider)
    {
        if(stressManagerObject == null)
        {
            stressManagerObject = GameObject.FindWithTag("Stress");
            stressManager = stressManagerObject.GetComponent<StressManager>();
        }
     
        if (collider.gameObject.tag == "zone1")
        {
            Debug.Log(stressManager);

            stressManager.SlowStressIncrease(power);
        }
    }

    void OnTriggerExit(Collider other)
    {
        stressManager.onExitZoneStress();

    }

    public void Interracted(MasterObject interractedObject)
    {
        //Debug.Log("message from enemy interacted");

        StartCoroutine(delaySpawnParticle());

    }

    IEnumerator delaySpawnParticle()
    {
        GameObject particle = Instantiate(particleDeath, transform.position, transform.rotation);
        var emission = particle.GetComponent<ParticleSystem>().emission;
        yield return new WaitForSeconds(3);
        emission.enabled = false;
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(4);
        Destroy(particle);
        death();
    }

    void attack()
    {

    }

    protected void death()
    {
        Destroy(this.gameObject);
    }
}
