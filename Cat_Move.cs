using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Move : MonoBehaviour
{
    public static Cat_Move instance;
    public Animator Cat;
    public GameObject cat;
    Vector3[] posi = new Vector3[4];

    public int posi_index = 0;
    public int x, y;
    int a = 2;
    int plag = 0;
    public bool cat_ok = false;

    void Awake()
    {
        Cat = GetComponent<Animator>();
        cat = GameObject.Find("Cat");
        Cat_Move.instance = this;
    }

    void Start()
    {
        Invoke("Cats_Move", 2.4f);
        x = Cow_Move.instance.x;
        y = Cow_Move.instance.y;
        Cow_Move.instance.point[2] = transform.position;
        Cow_Move.instance.point_y[2] = transform.position;
        print("포지션 x : " + posi[x]);
        print("포지션 y : " + posi[y]);
    }

    void Update()
    {
        Invoke("Move_Init", 2.4f);
        print("고양이" + transform.position);


        if (Cow_Move.instance.cow_ok == true || Chic_Move.instance.chic_ok == true || Cat_Move.instance.cat_ok == true)
        {
            x = Cow_Move.instance.x;
            y = Cow_Move.instance.y;
            Cow_Move.instance.point[2] = transform.position;
            Cow_Move.instance.point_y[2] = transform.position;
            posi_index = 0;
            cat_ok = false;
        }
        /*if (posi_index == 4)
        {
            x = Cow_Move.instance.x;
            print("x값 : " + x);
            y = Cow_Move.instance.y;
            print("y값 : " + y);
            Cow_Move.instance.point[2] = transform.position;
            Cow_Move.instance.point_y[2] = transform.position;
            posi_index = 0;
            Move_Init();
            print("들어오냐고:?");
        }*/
    }

    public void Cats_Move()
    {
        if (Cat != null)
        {
            Cat.SetInteger("CatState", 2);
        }
        else
        {
            Debug.Log("Cat State Error!");
        }
    }

    private void Posi_change(int a, int b)
    {
        Vector3 tmp;
        tmp = posi[a];
        posi[a] = posi[b];
        posi[b] = tmp;
    }

    private void Moving()
    {
        float step = 3f * Time.deltaTime;
        Vector3 current = transform.position;   //현재 위치 좌표


        if (x == a)
        {
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
                print("5");
                plag = 1;
            }

            print("냥이새끼의  x" + posi_index);
            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
                posi_index++;

            if (current == posi[3])
            {
                cat_ok = true;
                plag = 0;
            }


        }
        else if (y == a)
        {
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

            print("냥이새끼의  y" + posi_index);

            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);
            transform.rotation = Quaternion.FromToRotation(posi[posi_index], current);

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
                posi_index++;

            if (current == posi[3])
            {
                cat_ok = true;
                plag = 0;
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




}
