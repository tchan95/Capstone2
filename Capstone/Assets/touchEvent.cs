using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchEvent : MonoBehaviour
{
    public GameObject circle;
    Vector3 position;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        position = this.gameObject.transform.position;
        touchClick();
    }
    //터치시 오브젝트 확인 함수
    void touchClick()
    {
        //터치 입력이 들어올 경우
        if (Input.GetMouseButtonDown(0))
        {
            circle.SetActive(true);
        }
    }
}