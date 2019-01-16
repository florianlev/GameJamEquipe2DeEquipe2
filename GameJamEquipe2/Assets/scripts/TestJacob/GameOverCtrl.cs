using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCtrl : MonoBehaviour
{
    private Timer timer;
    public Text timeText;
    private int minutes;
    private int secondes;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        
        if (timer == null)
            Debug.Log("How di you get there ?!?!?!?");
    }

    private void Update()
    {
        timeText.text = "Your client Survived : " + timer.minutes + " : " + timer.seconds;
        Destroy(timer.gameObject);

    }

    public void Retry()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
