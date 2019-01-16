using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public bool AtObjective = false;
    public bool Dead = false;
    public StressManager stressManager;

    // Update is called once per frame
    void Update()
    {
        if (AtObjective)
        {
            stressManager.SlowStressIncrease(1);
            AtObjective = false;
        }
        if (Dead)
        {
            stressManager.StressDecrease(1);
            Destroy(this.gameObject);
        }
    }
}
