using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    
    public void click()
    {
        SceneManager.LoadScene(1);
    }
    public void ClickFrom3D()
    {
        SceneManager.LoadScene(0);
    }
}
