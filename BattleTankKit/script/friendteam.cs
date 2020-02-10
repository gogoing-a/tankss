using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendteam : MonoBehaviour
{
    public float teamstime = 10;
    public GameObject tans;
    public Color col;
    GameObject[] targets;
    public string[] TargetTag1 = { "Player" };
    public int number=0;
    public WarHp whp;
    public GameObject aaa;
    public int a;
    public selects ses;
    public pattern1 patt;
    // Start is called before the first frame update
    void Start()
    {
        a = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (ses.aa == 1 && patt.moshi == 2)
        {
            a = 17;
        }

        for (int i = 0; i < TargetTag1.Length; i++)
        {
            targets = GameObject.FindGameObjectsWithTag(TargetTag1[i]);
        }
        if (teamstime <= 0 && targets.Length < a)
        {
            number += 1;
            GameObject tan1 = Instantiate(tans, this.transform.position, this.transform.rotation);
            
            GameObject bbb = Instantiate(aaa, this.transform.position, Quaternion.identity);
            bbb.GetComponent<logfollow1>().log = tan1;
            teamstime = 10;

            if (tan1.GetComponent<tankHp>().HP <= 1)
            {
                Destroy(bbb);
            }
        }
        else
        {
            teamstime -= 2 * Time.deltaTime;
        }
    }
}
