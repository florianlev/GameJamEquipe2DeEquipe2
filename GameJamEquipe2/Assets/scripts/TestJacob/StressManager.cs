using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StressManager : MonoBehaviour
{
    public float CurrentStress = 0;
    public float MaxStress = 100;
    public float stressFactor = 0;
    public float StressReductionRate = 0.5f;
    public bool IsStressing = false;

    private Timer timer;
    public Slider stressBar;
    private Animator animator;
    GameObject aiObject;
    private AI Ai;



    // Update is called once per frame

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        stressBar.value = calculateStress();
        animator = gameObject.GetComponent<Animator>();
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
            timer.playerIsAlive = false;
            animator.SetTrigger("wakeUp");
            aiObject = GameObject.FindWithTag("client");
            Ai = aiObject.GetComponent<AI>();
            Ai.setDestination();
            //SceneManager.LoadScene("GameOver");
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
