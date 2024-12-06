using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private Shooting gunComponent;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        gunComponent = GameObject.FindGameObjectWithTag("Gun").GetComponent<Shooting>();
        gunComponent.enabled = true;
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
            gunComponent.enabled = !gunComponent.enabled;
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
