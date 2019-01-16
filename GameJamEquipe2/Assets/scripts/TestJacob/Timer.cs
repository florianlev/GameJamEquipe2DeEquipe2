using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float Survivaltime = 0;
    public int seconds = 0;
    public int minutes = 0;
    public Text TimeText;
    // Start is called before the first frame update
    void Start()
    {
        TimeText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Survivaltime += Time.deltaTime;
        minutes = (int)Survivaltime / 60;
        seconds = (int)Survivaltime % 60;

        TimeText.text = "Time : " + minutes + " : " + seconds;

    }
}
