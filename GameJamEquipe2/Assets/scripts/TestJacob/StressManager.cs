using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StressManager : MonoBehaviour
{
    public float CurrentStress = 0;
    public float MaxStress = 100;
    public float stressFactor = 0;
    public float StressReductionRate = 0.5f;
    public bool IsStressing = false;

    // Update is called once per frame
    void Update()
    {
        if (CurrentStress > 0 && !IsStressing)
        {
            CurrentStress -= Time.deltaTime / StressReductionRate;
            if (CurrentStress < 0)
                CurrentStress = 0;
        }

        CurrentStress += stressFactor * Time.deltaTime;

    }
    public void suddenStress(float income)
    {
        CurrentStress += income;
    }

    public void SlowStressIncrease(float NewStress)
    {
        stressFactor += NewStress;

        if (!IsStressing && stressFactor > 0)
            IsStressing = true;
        
        
        if (CurrentStress >= MaxStress)
            GameOver();

    }
    public void StressDecrease(float FactorRemove)
    {
        stressFactor -= FactorRemove;
        if (stressFactor == 0)
            IsStressing = false;

    }
    public void GameOver()
    {

    }

}
