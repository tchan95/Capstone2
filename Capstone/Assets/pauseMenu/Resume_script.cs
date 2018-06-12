using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resume_script : MonoBehaviour {

    public GameObject pauseMenu;

    public void resumeSetActive()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
