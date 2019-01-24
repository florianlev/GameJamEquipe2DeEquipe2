using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject logo;
    public GameObject story;
    public GameObject fondSoleil;
    public GameObject tutoMenu;
    public GameObject buttonPlay;
    private Button previousButton;

    private bool inMainMenu = true;
    private bool inStory = true;
    private bool inTuto = false;


    void Update()
    {
        if (Input.GetButtonDown("cancel") && !inMainMenu)
        {
            inTuto = false;

            mainMenu.gameObject.SetActive(true);
            logo.gameObject.SetActive(true);

            controlsMenu.gameObject.SetActive(false);
            creditsMenu.gameObject.SetActive(false);
            fondSoleil.gameObject.SetActive(false);
            tutoMenu.gameObject.SetActive(false);

        }

        if (Input.GetButtonDown("Take_P1") && inStory)
        {
            inStory = false;
            mainMenu.gameObject.SetActive(true);
            logo.gameObject.SetActive(true);
            story.gameObject.SetActive(false);
        }

        if (Input.GetButtonDown("Take_P1") && inTuto)
        {
            inTuto = false;
            StartGame();
        }


    }

    public void OnControlMenu()
    {
        inMainMenu = false;

    }

    public void onTutoMenu()
    {
        inMainMenu = false;

        StartCoroutine(changebool());
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Cinématique");
    }

    public void restart()
    {
        SceneManager.LoadScene("MainScene");

    }

    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator changebool()
    {
        yield return new WaitForSeconds(0.2f);
        inTuto = true;

    }



}
