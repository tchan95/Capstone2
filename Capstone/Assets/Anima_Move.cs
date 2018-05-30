using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima_Move : MonoBehaviour {

    public GameObject Apple;

    void Awake()
    {
        Apple = GameObject.Find("Apple");
    }
    void Start () {
        Destroy(Apple, 0.1f);
    }
	
	// Update is called once per frame
	void Update () {
    
    }


  

    
}
