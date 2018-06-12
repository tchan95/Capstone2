using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timecount : MonoBehaviour
{

    public Text timecount_text;
    public float timecount = 0.0f;
    bool isTimeCount = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startTimeCount();
    }

    public void startTimeCount()
    {
        if (isTimeCount)
        {
            timecount += Time.deltaTime;
            timecount_text.text = "게임시간 :  " + ((int)timecount + 1) + " 초";
        }
    }
}
