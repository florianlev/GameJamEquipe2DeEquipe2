using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public int speed;
    public float power;

    private StressManager stressManager;
    GameObject stressManagerObject;

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

    void attack()
    {

    }

    void death()
    {

    }
}
