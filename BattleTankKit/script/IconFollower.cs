using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IconFollower : MonoBehaviour
{
    public float isdou = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void click()
    {
        SceneManager.LoadScene("Star");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pao")
        {
            isdou = 1f;
        }
    }
}
