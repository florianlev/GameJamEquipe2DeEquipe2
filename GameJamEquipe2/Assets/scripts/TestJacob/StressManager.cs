﻿using System.Collections;
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
        if (!IsStressing && CurrentStress >= 0)
        {


            CurrentStress -= Time.deltaTime / StressReductionRate;
            stressBar.value = calculateStress();

        }

    }


    //sert a augmenter le taux de stress / Seconde
    public void SlowStressIncrease(float newStress)
    {
        IsStressing = true;
        CurrentStress += Time.deltaTime * newStress;

        stressBar.value = calculateStress();

        if(CurrentStress >= 100)
        {
            // TO DO : GameOver
            CurrentStress = 100;
        }

    }

    public void onExitZoneStress()
    {
        IsStressing = false;
    }


    float calculateStress()
    {
        return CurrentStress / MaxStress;
    }


    

}
