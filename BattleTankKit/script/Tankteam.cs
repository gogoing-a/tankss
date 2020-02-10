using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tankteam : MonoBehaviour
{
    public float teamstime = 10;
    public GameObject tans;
    GameObject[] targets;
    public string[] TargetTag = { "NPC" };
    public int numbers=0;
    public WarHp whp;
    public GameObject aaa;
    public int b;
    public selects ses;
    public pattern1 patt;
    // Start is called before the first frame update
    void Start()
    {
        b = 10;
    }

    // Update is called once per frame
    void Update()
    {

        if(ses.aa==2&&patt.moshi==2)
        {
            b = 17;
        }

        for (int i = 0; i < TargetTag.Length; i++)
        {
            targets = GameObject.FindGameObjectsWithTag(TargetTag[i]);         
        }
        if(teamstime<=0&&targets.Length<b)
        {
            numbers += 1;
            GameObject tan1 = Instantiate(tans, this.transform.position, this.transform.rotation);
            GameObject bbb = Instantiate(aaa, this.transform.position, Quaternion.identity);
            bbb.GetComponent<logfollow1>().log = tan1;
            teamstime = 10;

            //if (tan1.GetComponent<tankHp>().HP <= 1)
            //{
            //    Debug.Log("aaa1");
            //    Destroy(bbb);
            //}
        }
        else
        {
            teamstime -= 2 * Time.deltaTime;
        }
    }
}
