using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcGun : MonoBehaviour
{
    public GameObject gun;
    public GameObject bull;
    public float speed = 250;
    public float speed1 = 700;
    private Transform gunposition;
    private float isbutt=0;
    public IEnumerator coroutine1;
    // Start is called before the first frame update
    void Start()
    {
        gunposition = transform.Find("GunPosition");
        coroutine1 = WaitAndPrint(0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isbutt<=0)
        {
            isbutt = Random.Range(0, 20);
        }
        else
        {
            isbutt -= 1 * Time.deltaTime;
        }
    }

    public void shoot()
    {
        if (isbutt >= 1)
        {
            //StopCoroutine(coroutine1);
            GameObject go1 = Instantiate(gun, gunposition.position, gunposition.rotation) as GameObject;
            go1.GetComponent<Rigidbody>().velocity = go1.transform.forward * speed1;
            
        }
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            GameObject go2 = Instantiate(bull, gunposition.position, gunposition.rotation) as GameObject;
            go2.GetComponent<Rigidbody>().velocity = go2.transform.forward * speed;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
