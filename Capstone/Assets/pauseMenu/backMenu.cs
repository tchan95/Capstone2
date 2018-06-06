using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backMenu : MonoBehaviour {

    public GameObject pauseMenu;

    public void pauseMenuSetActive()
    {
        pauseMenu.SetActive(!pauseMenu.active);
        Time.timeScale = 0;
    }
    
}

