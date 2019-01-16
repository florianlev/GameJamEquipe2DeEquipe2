using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCtrl : MonoBehaviour
{
    private Timer timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        if (timer == null)
            Debug.Log("How di you get there ?!?!?!?");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
