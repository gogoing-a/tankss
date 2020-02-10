using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletball : MonoBehaviour
{
    public GameObject shellboms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject.Instantiate(shellboms, transform.position, transform.rotation);
        GameObject.Destroy(this.gameObject);
    }

}
