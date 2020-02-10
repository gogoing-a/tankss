using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removebutt : MonoBehaviour
{
    public float a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(a>3)
        {
            GameObject.Destroy(this.gameObject);
            a = 0;
        }
        else
        {
            a += 1 * Time.deltaTime;
        }
    }
}
