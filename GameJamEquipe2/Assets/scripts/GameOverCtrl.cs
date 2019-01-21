using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCtrl : MonoBehaviour
{
    public Text timeText;
    private int minutes;
    private int secondes;
    // Start is called before the first frame update
    void Start()
    {
        int minutes = PlayerPrefs.GetInt("minutes");
        int seconds = PlayerPrefs.GetInt("seconds");
        timeText.text = "Your client slept : " + minutes + " : " + seconds;
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
