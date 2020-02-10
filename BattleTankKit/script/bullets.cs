using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullets : MonoBehaviour
{
    public Text text;
    public float bulleTime=1f;
    // Start is called before the first frame update
    void Start()
    {
        text.text = bulleTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (bulleTime/3 < 100)
        {
            bulleTime += 1f;
            text.text = string.Format("{0:D2}", (int)bulleTime / 3);
        }
    }
}
