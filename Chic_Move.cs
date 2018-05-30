using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chic_Move : MonoBehaviour
{
    public static Chic_Move instance;
    public Animator Chicken;
    public GameObject chicken;
    Vector3[] posi = new Vector3[4];

    public int posi_index = 0;
    public int x, y;
    int a = 1;
    int plag = 0;
    public bool chic_ok = false;

    void Awake()
    {
        Chicken = GetComponent<Animator>();
        chicken = GameObject.Find("Chicken");
        Chic_Move.instance = this;
    }

    // Update is called once per frame
    void Start()
    {
        Invoke("Chicken_Move", 2.4f);
        x = Cow_Move.instance.x;
        y = Cow_Move.instance.y;
        Cow_Move.instance.point[1] = chicken.transform.position;
        Cow_Move.instance.point_y[1] = chicken.transform.position;
    }

    void Update()
    {
        Invoke("Move_Init", 2.4f);
        print("닭" + transform.position);

        /*if (Cow_Move.instance.cow_ok == true || Chic_Move.instance.chic_ok == true || Cat_Move.instance.cat_ok == true)
        {
            x = Cow_Move.instance.x;
            y = Cow_Move.instance.y;
            Cow_Move.instance.point[1] = chicken.transform.position;
            Cow_Move.instance.point_y[1] = chicken.transform.position;
            posi_index = 0;
            chic_ok = false;
        }*/


        /*if (posi_index == 4)
        {
            x = Cow_Move.instance.x;
            y = Cow_Move.instance.y;
            Cow_Move.instance.point[1] = chicken.transform.position;
            Cow_Move.instance.point_y[1] = chicken.transform.position;
            posi_index = 0;
            Move_Init();
            print("들어오나");
        }*/
    }

    public void Chicken_Move()
    {
        if (Chicken != null)
        {
            Chicken.SetInteger("ChicState", 2);
        }
        else
        {
            Debug.Log("Chicken State Error!");
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


                plag = 1;
            }

            print("닭새끼의 x" + posi_index);
            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);
            transform.rotation = Quaternion.FromToRotation(posi[posi_index], current);

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
                posi_index++;

            if (current == posi[3])
            {
                chic_ok = true;
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
                print("4");
                plag = 1;
            }

            print("닭새끼의  y" + posi_index);

            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
                posi_index++;

            if (current == posi[3])
            {
                chic_ok = true;
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
