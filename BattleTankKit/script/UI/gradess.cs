using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gradess : MonoBehaviour
{
    public int grade=0;
    public int grade1=0;
    public friendteam fri;
    public Tankteam tkm;
    public Text score;
    public Text score1;
    public selects sle;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        grade1 = tkm.numbers * 10;
        grade = fri.number * 10;

        if(sle.aa==1)
        {
            score.text = grade.ToString();
        }
        else
        {
            score.text = grade1.ToString();
        }
        score1.text = score.text;
    }
}
