using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    public GameObject dies;
    public GameObject dis1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "di")
        {
            Destroy(dis1);
            Debug.Log("wuwuwuuw");
            GameObject die = Instantiate(dies, this.transform.position, this.transform.rotation);
        }
    }
}
