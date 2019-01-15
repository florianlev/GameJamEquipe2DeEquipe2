using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressManager : MonoBehaviour
{
    public float CurrentStress = 0;
    public float MaxStress = 100;
    public bool IsStressing = false;

    private void OnCollisionEnter(Collision collision)
    {
        IsStressing = true;
    }
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(IsStressing)
        {
            StressIncrease(1);
        }
    }
    public void StressIncrease(float NewStress)
    {
        CurrentStress += NewStress;
        if (CurrentStress >= MaxStress)
            GameOver();

    }
    public void GameOver()
    {

    }

}
