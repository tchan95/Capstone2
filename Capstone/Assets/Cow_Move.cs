using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow_Move : MonoBehaviour
{
    public Animator Cow;
    public static Cow_Move instance;
    public GameObject cow;

    public Vector3[] point = new Vector3[3];
    public Vector3[] point_y = new Vector3[3];
    Vector3[] posi = new Vector3[4];
    int posi_index = 0;

    public int x, y;
    int a = 0;
    int plag = 0;
    

    void Awake()
    {
        Cow = GetComponent<Animator>();
        cow = GameObject.Find("Cow");
        Cow_Move.instance = this;
        Rand();
    }

    // Update is called once per frame
    void Start()
    {
        Cow.Play("eat");
        Invoke("Cows_Move", 2.4f);
        point[0] = cow.transform.position;
        point_y[0] = cow.transform.position;
    }

    void Update()
    {
        Invoke("Move_Init", 2.0f); // 2.4초후 실행, 변경 금지
        Invoke("Move_Finish", 6.7f);
    }


    public void Cows_Move() // animator 실행하는 함수(변경 금지)
    {
        if (Cow == null)
        {
            Debug.Log("Cow State Error!");
        }
    }

    public void Rand() // 0,3 -> 0,1,2 까지 출력
    {
        x = Random.Range(0, 3);
        y = Random.Range(0, 3);

        while (true)
        {
            if (x == y)
            {
                y = Random.Range(0, 3);
            }
            else if (x != y)
            {
                break;
            }
        }
    }

    public void Moving()
    {
        float step = 5f * Time.deltaTime;
        Vector3 current = transform.position;

        if (x == a)
        {
            Cow.Play("jump");
            if (plag == 0)
            {
                posi[0] = point[x];
                point[x].z += 8f;
                posi[1] = point[x];
                point[y].z += 8f;
                posi[2] = point[y];
                point[y].z -= 8f;
                posi[3] = point[y];

                plag = 1;
            }

            transform.LookAt(posi[posi_index]);
            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);
       

            //목표지점에서 현재지점으로 회전

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
            {
                posi_index++;
            }
        }
        else if (y == a)
        {
            Cow.Play("jump");
            if (plag == 0)
            {
                //y -> x로 이동할때
                posi[0] = point_y[y];
                point_y[y].z += 8f;
                posi[1] = point_y[y];
                point_y[x].z += 8f;
                posi[2] = point_y[x];
                point_y[x].z -= 8f;
                posi[3] = point_y[x]; 

                plag = 1;
            }
            transform.LookAt(posi[posi_index]);
            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);



            //현재 좌표에서 목표 좌표로 회전

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
            {
                posi_index++;
            }

        }
    }
    public void Move_Init()
    {
        if (posi_index < 4)
        {
            Moving();
        }
    }

    public void Move_Finish()
    {
        if (transform.rotation.y == 0)
        {
            return;
        }
        if (transform.rotation.y >= 0 && transform.rotation.y <= 180)
        {
            if (x == a)
            {
                Cow.Play("jump");
                transform.Rotate(0, -10, 0);
            }
            else if (y == a)
            {
                Cow.Play("jump");
                transform.Rotate(0, 10, 0);
            }
        }
    }
}


