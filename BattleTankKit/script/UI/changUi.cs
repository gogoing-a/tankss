using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changUi : MonoBehaviour
{
    public Canvas star;
    public Canvas select;
    public Canvas parten;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void onclick()
    {
        select.enabled = false;
        star.enabled = true ;
    }

    public void onclick1()
    {
        parten.enabled = false;
        select.enabled = true;
    }
}
