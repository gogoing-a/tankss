using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeSence : MonoBehaviour
{
    public string a;
    public Canvas star;
    public Canvas select;
    public GameObject set;
    public Canvas pattern;
    // Start is called before the first frame update
    void Start()
    {
        select.enabled = false;
        pattern.enabled = false;
    }

    public void onclick()
    {
        select.enabled=true;
        star.enabled=false;
    }

    public void setclick()
    {
        set.SetActive(true);
    }

    public void setclick1()
    {
       set.SetActive(false);
    }

    public void patterns()
    {
        pattern.enabled=true;
        select.enabled = false;
    }
}
