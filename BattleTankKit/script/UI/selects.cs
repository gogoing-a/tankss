using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selects : MonoBehaviour
{
    public int aa=0;
    public GameObject tank1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //RenderSettings.fog = true;
        if(aa==1)
        {
            tank1.SetActive(true);
        }
    }

    public void onclick()
    {
        aa = 1;
    }
}
