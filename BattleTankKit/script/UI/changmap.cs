using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changmap : MonoBehaviour
{
    public GameObject star;
    public GameObject Pk;
    public GameObject fish;
    public GameObject Rank;
    public GameObject pattern;
    public MyHp mh;
    public MyHp mh1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update()
    {
        

        if (mh.hp<=1)
        {
            Pk.SetActive(false);
            fish.SetActive(true);
            Cursor.visible = true;
            //SceneManager.LoadScene("fish");
        }
        if (mh1.hp <= 1)
        {
            Pk.SetActive(false);
            fish.SetActive(true);
            Cursor.visible = true;
            //SceneManager.LoadScene("fish");
        }
    }
    public void onclick()
    {
        star.SetActive(false);
        Pk.SetActive(true);
        Cursor.visible = false;
    }

    public void onclick1()
    {        
        SceneManager.LoadScene("Star");        
    }

    public void rankonclick()
    {
        Rank.SetActive(true);
    }

    public void exctonclick()
    {
        Rank.SetActive(false);
    }
}
