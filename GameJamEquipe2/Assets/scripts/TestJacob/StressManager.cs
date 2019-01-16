using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StressManager : MonoBehaviour
{
    public float CurrentStress = 0;
    public float MaxStress = 100;
    public float stressFactor = 0;
    public float StressReductionRate = 0.5f;
    public bool IsStressing = false;

    public Slider stressBar;

    // Update is called once per frame

    void Start()
    {
        stressBar.value = calculateStress();

    }

    void Update()
    {
        //Diminution du stress si rien ne le stress présentement
        if (CurrentStress > 0 && !IsStressing)
        {
            CurrentStress += Time.deltaTime / StressReductionRate;
            if (CurrentStress < 0)
                CurrentStress = 0;
        }

        //Augmentation du stress selon le facteur de stress
        stressBar.value = calculateStress();


    }


    //sert a augmenter le taux de stress / Seconde
    public void SlowStressIncrease(float NewStress)
    {
        stressFactor += NewStress;

        if (!IsStressing && stressFactor > 0)
            IsStressing = true;

        Debug.Log(CurrentStress);
        CurrentStress -= stressFactor * Time.deltaTime;

        stressBar.value = calculateStress();

    }

    //sert a diminuer le stress / Seconde
    public void StressDecrease(float FactorRemove)
    {
        stressFactor -= FactorRemove;
        //Vérifie si le personnage stress
        if (stressFactor == 0)
            IsStressing = false;

    }

    float calculateStress()
    {
        return CurrentStress / MaxStress;
    }


    

}
