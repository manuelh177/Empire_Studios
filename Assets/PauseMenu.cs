using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseMenu.activeSelf)
            {
                Time.timeScale = 0f;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                pauseMenu.SetActive(false);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
}
