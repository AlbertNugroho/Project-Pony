using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public InputActionReference menubutton;
    public GameObject menu;
    public GameObject DeathScreen;
    public GameObject retry;
    public HighScoreManager manager;

    private bool isMenu;
    private AudioManager am;
    private void Awake()
    {
        am = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Start()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
        DeathScreen.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (menubutton.action.WasPressedThisFrame())
        {
            PauseSystem();
        }
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void PauseSystem()
    {
        if (DeathScreen.activeSelf) return;

        if (!isMenu)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            menu.SetActive(true);
            Time.timeScale = 0;
            isMenu = true;
        }
        else if(isMenu)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            menu.SetActive(false);
            Time.timeScale = 1;
            isMenu = false;
        }
    }

    public void Death()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        DeathScreen.SetActive(true);
        manager.GetHighScore();
        am.playclip(am.deathfx);
        am.stopMusic();
        EventSystem.current.SetSelectedGameObject(retry);
    }
}
