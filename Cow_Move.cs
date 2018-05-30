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
    int i;
    public bool cow_ok = false;
    bool first_time = true;

    public GameObject chicken;
    public GameObject cat;

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
        cat = GameObject.Find("Cat");
        chicken = GameObject.Find("Chicken");

        Invoke("Cows_Move", 2.4f);
        print(x + "&" + y);
        point[0] = cow.transform.position;
        point_y[0] = cow.transform.position;


    }

    void Update()
    {
        Invoke("Move_Init", 2.4f); // 2.4초후 실행, 변경 금지
        print("소" + transform.position);

        Chek();

        // print("x값 : " + x + "  y값 : " + y);

        /*if (posi_index == 4)
        {
            point[0] = cow.transform.position;
            point_y[0] = cow.transform.position;
            Rand();
            posi_index = 0;
            Move_Init();
            print("들어오니?");
        }*/
    }

    private void Chek()
    {
        if (Cow_Move.instance.cow_ok == true || Chic_Move.instance.chic_ok == true || Cat_Move.instance.cat_ok == true)
        {
            Time.timeScale = 0.0f;
            Rand();
            point[0] = cow.transform.position;
            point_y[0] = cow.transform.position;
            posi_index = 0;
            cow_ok = false;
            Chic_Move.instance.chic_ok = false;
            Cat_Move.instance.cat_ok = false;
              Chic_Move.instance.x = x;
              Chic_Move.instance.y = y;
              Cat_Move.instance.x = x;
              Cat_Move.instance.y = y;
              point[0] = cow.transform.position;
              point_y[0] = cow.transform.position;
              point[1] = chicken.transform.position;
              print("치킨의 위치 : " + point[1]);
              point_y[1] = chicken.transform.position;
              point[2] = cat.transform.position;
              print("고양의 위치 : " + point[2]);
              point_y[2] = cat.transform.position;

              posi_index = 0; 
              Chic_Move.instance.posi_index = 0;
              Cat_Move.instance.posi_index = 0;
            Time.timeScale = 1.0f;
        }
    }

    private void Setsuffle(int a)     // 셔플 횟수 설정. 좆같음이 가득차서 못만들겠음.
    {
        int count = 0;
        if (count != a)
        {

            count++;
        }
    }

    public void Cows_Move() // animator 실행하는 함수(변경 금지)
    {
        if (Cow != null)
        {
            Cow.SetInteger("CowState", 2);
        }
        else
        {
            Debug.Log("Cow State Error!");
        }
    }

    public void Rand() // 0,3 -> 0,1,2 까지 출력
    {

        //fals로 되있던게 현재 좌표와 posi[3]좌표가 같게 되면 true로 바뀜 그러면 랜덤함수에서 다시 rand을 돌림. plag는 moving함수에서 바꿈
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
        float step = 3f * Time.deltaTime;
        Vector3 current = transform.position;

        if (x == a)
        {
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
            print("소새끼의 x " + posi_index);

            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);
            transform.rotation = Quaternion.FromToRotation(posi[posi_index], current);

            //목표지점에서 현재지점으로 회전

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
            {
                posi_index++;
            }

            if (current == posi[3])
            {
                print("들어오나?????");
                cow_ok = true;
                plag = 0;
            }

        }
        else if (y == a)
        {
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
                print("2");
                plag = 1;
            }
            print("소새끼의 y" + posi_index);

            transform.position = Vector3.MoveTowards(current, posi[posi_index], step);
            transform.rotation = Quaternion.FromToRotation(posi[posi_index], current);


            //현재 좌표에서 목표 좌표로 회전

            if (Vector3.Distance(current, posi[posi_index]) == 0f)
                posi_index++;

            if (current == posi[3])
            {
                print("들어오나?");
                cow_ok = true;
                plag = 0;
            }

        }
    }
    public void Move_Init()
    {
        if (posi_index < 4)
        {
            Moving();
            print("되나 진짜로?");
        }
    }

}
