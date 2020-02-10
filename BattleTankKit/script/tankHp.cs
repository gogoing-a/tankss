using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankHp : MonoBehaviour
{
    public int HP=10;
    public GameObject Die;
    public int a;
    
    private void OnTriggerEnter(Collider other)
    {

        if(other.tag=="Pao")
        {
            HP -= 10;            
        }
        if(other.tag=="butt")
        {
            HP -= 1;            
        }
    }

    private void Update()
    {
        if(HP<=0)
        {         
            Destroy(this.gameObject);
            GameObject die = Instantiate(Die,this.transform.position,this.transform.rotation);
            HP = 1;
        }
    }

    // Start is called before the first frame update

}
