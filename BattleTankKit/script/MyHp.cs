using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyHp : MonoBehaviour
{
    public Text texthp;
    public float hp=50f;
    public GameObject dies;
    // Start is called before the first frame update
    void Start()
    {
        texthp.text = hp.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pao")
        {
            hp -= 10;
            texthp.text = hp.ToString();
        }
        if (other.tag == "butt")
        {
            hp -= 1;
            texthp.text = hp.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        texthp.text = hp.ToString();
        if (hp <= 0)
        {           
            Destroy(this.gameObject);
            GameObject die = Instantiate(dies, this.transform.position, this.transform.rotation);
            hp = 1;
        }
    }
}
