using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Move : MonoBehaviour
{
    public Animator Cat;
    public GameObject cat;
    Vector3[] posi = new Vector3[4];

    int posi_index = 0;
    int x, y;
    int a = 2;
    int plag = 0;

    void Awake()
    {
        Cat = GetComponent<Animator>();
        cat = GameObject.Find("Cat");
    }

    void Start()
    {
        Invoke("Cats_Move", 2.4f);
        x = Cow_Move.instance.x;
        y = Cow_Move.instance.y;
        Cow_Move.instance.point[2] = transform.position;
        Cow_Move.instance.point_y[2] = transform.position;
    }

    void Update()
    {
        Invoke("Move_Init", 2.0f);
        Invoke("Move_Finish",6.7f);
    }

    public void Cats_Move()
    {
        if (Cat == null)
        { 
           Debug.Log("Cat State Error!");
        }
    }

    private void Moving()
    {
        float step = 5f * Time.deltaTime;
        Vector3 current = transform.position;   //현재 위치 좌표
  

        if (x == a)
        {
            Cat.Play("jump");
            if (plag == 0)
            {
                //x -> y로 이동할때
                posi[0] = Cow_Move.instance.point[x];
                Cow_Move.instance.point[x].z += 8f;
                posi[1] = Cow_Move.instance.point[x];
                Cow_Move.instance.point[y].z += 8f;
                posi[2] = Cow_Move.instance.point[y];
                Cow_Move.instance.point[y].z -= 8f;
                posi[3] = Cow_Move.instance.point[y];

                plag = 1;
            }
            transform.LookAt(posi[posi_index]);
            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
            {
                posi_index++;
            }


        }
        else if (y == a)
        {
            Cat.Play("jump");
            if (plag == 0)
            {
                //y -> x로 이동할때
                posi[0] = Cow_Move.instance.point_y[y];
                Cow_Move.instance.point_y[y].z += 8f;
                posi[1] = Cow_Move.instance.point_y[y];
                Cow_Move.instance.point_y[x].z += 8f;
                posi[2] = Cow_Move.instance.point_y[x];
                Cow_Move.instance.point_y[x].z -= 8f;
                posi[3] = Cow_Move.instance.point_y[x];

                plag = 1;
            }

            transform.LookAt(posi[posi_index]);
            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);


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
                Cat.Play("jump");
                transform.Rotate(0, -10, 0);
            }
            else if (y == a)
            {
                Cat.Play("jump");
                transform.Rotate(0, 10, 0);
            }
        }
    }
}

