using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class num : MonoBehaviour
{
    public int a=0;
    public GameObject esc;
    
    // Start is called before the first frame update
    void Start()
    {
        esc.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Cursor.visible = false;
        if (Input.GetKeyDown(KeyCode.Escape)&&a==0)
        {
            Cursor.visible = true;
            Time.timeScale = 0;
            a = 1;
            esc.SetActive(true);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && a == 1)
        {
            Cursor.visible = false;
            Time.timeScale = 1;
            a = 0;
            esc.SetActive(false);
        }   
        
    }

    public void conclick()
    {
        Time.timeScale = 1;
        a = 0;
        esc.SetActive(false);
    }

    public void exctclick()
    {
        SceneManager.LoadScene("Star");
        Time.timeScale = 1;
    }
}
