using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rockball : MonoBehaviour
{

    public GameObject shellbom;
    public float b;
    public float dou=0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (b > 5)
        {
            GameObject.Destroy(this.gameObject);
            b = 0;
        }
        else
        {
            b += 1 * Time.deltaTime;
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        GameObject.Instantiate(shellbom,transform.position,transform.rotation);
        GameObject.Destroy(this.gameObject);
    }


}
