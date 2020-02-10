using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selects1 : MonoBehaviour
{
    public selects se;
    public GameObject tank;
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(se.aa==2)
        {
            tank.SetActive(true);
        }
    }

    public void onclick()
    {
        se.aa = 2;
    }
}
