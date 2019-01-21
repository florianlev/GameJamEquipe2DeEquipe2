using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

using UnityEngine.UI;


public class MenuController : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject logo;
    public GameObject story;
    private Button previousButton;

    private bool inMainMenu = true;
    private bool inStory = true;


    void Update()
    {
        if (Input.GetButtonDown("cancel") && !inMainMenu)
        {
            controlsMenu.gameObject.SetActive(false);
            creditsMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }

        if(Input.GetButtonDown("Take_P1") && inStory)
        {
            inStory = false;
            mainMenu.gameObject.SetActive(true);
            logo.gameObject.SetActive(true);
            story.gameObject.SetActive(false);

        }
    }

    public void OnControlMenu()
    {
        inMainMenu = false;

    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }



}
