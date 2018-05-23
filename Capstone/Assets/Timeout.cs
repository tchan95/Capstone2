using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timeout : MonoBehaviour {

    public float timeout = 10.0f;
    public Text timeout_text;
    bool isTimeout = true;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        Invoke("startTimeout", 7.8f);
    }

    public void startTimeout() 
    {
        if (isTimeout)
        {
            timeout -= Time.deltaTime;
            timeout_text.text = "제한시간 :  " + ((int)timeout + 1) + " 초";

            if (timeout < 0F)               //타임아웃 씬 추가
            {
                timeout_text.text = "T i m e  o u t";
                isTimeout = false;
            }
        }
    }
}
