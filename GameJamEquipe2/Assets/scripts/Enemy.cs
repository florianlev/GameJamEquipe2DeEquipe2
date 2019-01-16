using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    public virtual int speed { get; set; }
    public virtual int power { get; set; }

    private StressManager stressManager;

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
        GameObject stressManagerObject = GameObject.FindWithTag("Stress");
        stressManager = stressManagerObject.GetComponent<StressManager>();

        if (collider.gameObject.tag == "zone1")
        {
            stressManager.SlowStressIncrease(power);
        }
    }

    void attack()
    {

    }

    void death()
    {

    }
}
