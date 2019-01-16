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
        //Diminution du stress si rien ne le stress présentement
        if (CurrentStress > 0 && !IsStressing)
        {
            CurrentStress -= Time.deltaTime / StressReductionRate;
            if (CurrentStress < 0)
                CurrentStress = 0;
        }

        //Augmentation du stress selon le facteur de stress
        CurrentStress += stressFactor * Time.deltaTime;

    }
   
    //sert a augmenter le taux de stress / Seconde
    public void SlowStressIncrease(float NewStress)
    {
        stressFactor += NewStress;

        if (!IsStressing && stressFactor > 0)
            IsStressing = true;
        
        
        

    }
    //sert a diminuer le stress / Seconde
    public void StressDecrease(float FactorRemove)
    {
        stressFactor -= FactorRemove;
        //Vérifie si le personnage stress
        if (stressFactor == 0)
            IsStressing = false;

    }
    

}
