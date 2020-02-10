using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarHp : MonoBehaviour
{
    // Start is called before the first frame update
    public float hp = 2000;
    public int[] DamageLowerThan = { 10 };
    public GameObject[] DecayObject;
    public gradess gar;
    void Start()
    {

    }

    void Update()
    {
        if ( DecayObject.Length != DamageLowerThan.Length || DecayObject.Length <= 0)
            return;

        if(hp<=1)
        {
            gar.grade += 2000;
            gar.grade1 += 2000;
        }

        for (int i = 0; i < DecayObject.Length; i++)
        {
            if (hp > DamageLowerThan[i])
            {
                DecayObject[i].SetActive(false);
            }
        }

        for (int i = 0; i < DecayObject.Length; i++)
        {
            if (hp < DamageLowerThan[i])
            {
                DecayObject[i].SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pao")
        {
            hp -= 10;
        }
        if (other.tag == "butt")
        {
            hp -= 1;
        }
    }

}
