using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public GameObject help;
    public GameObject back;
    public GameObject helpmenu;
    private bool isOpenHelp;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isOpenHelp = false;
        Time.timeScale = 1;
        helpmenu.SetActive(false);
    }
    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void showHelp()
    {
        if(!isOpenHelp)
        {
            helpmenu.SetActive(true);
            isOpenHelp = true;
            EventSystem.current.SetSelectedGameObject(back);
        }else if(isOpenHelp)
        {
            helpmenu.SetActive(false);
            isOpenHelp = false;
            EventSystem.current.SetSelectedGameObject(help);
        }
    }
}
