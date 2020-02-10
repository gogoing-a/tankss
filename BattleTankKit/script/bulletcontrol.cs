using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bulletcontrol : MonoBehaviour
{
    public GameObject gan;
    public GameObject bull;
    public GameObject explors;
    public float speed = 250;
    public float speedGun = 700;
    public float time = 100;
    public Transform filePosition;
    public bool isPaoandbull = false;
    private IEnumerator coroutine;
    public Text text;
    public float bulleTime = 1f;
    public bool isfair=false;
    // Start is called before the first frame update
    void Start()
    {
        //filePosition = transform.Find("FilePosition");
        coroutine = WaitAndPrint(0.05f);
        text.text = bulleTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulleTime / 3 < 100)
        {
            bulleTime += Time.deltaTime*80;
            text.text = string.Format("{0:D2}", (int)bulleTime / 3);           
        }

        if(bulleTime/3>100)
        {
            bulleTime = 300;
        }

        if (isfair == true)
        {
            bulleTime = 1f;
            isfair = false;
        }

        if (Input.GetMouseButtonUp(0)&&isPaoandbull==false&&text.text==time.ToString())
        {
            GameObject go= Instantiate(gan, filePosition.position, filePosition.rotation) as GameObject;
            GameObject gos = Instantiate(explors, filePosition.position, filePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * speedGun;
            isfair = true;            
        }
        
        if(Input.GetMouseButtonDown(0)&& isPaoandbull==true)
        {
            StartCoroutine(coroutine);
        }
        else if(Input.GetMouseButtonUp(0) && isPaoandbull == true)
        {
            StopCoroutine(coroutine);
            coroutine = WaitAndPrint(0.05f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(isPaoandbull==false)
            {
                isPaoandbull = true;
            }
            else
            {
                isPaoandbull = false;
            }
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            GameObject go = Instantiate(bull, filePosition.position, filePosition.rotation) as GameObject;
            go.GetComponent<Rigidbody>().velocity = go.transform.forward * speed;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
