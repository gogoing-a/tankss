using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logFollwo : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 shakePos = Vector3.zero;
    public IconFollower icf;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (icf.isdou > 0)
        {
            transform.localPosition -= shakePos;
            shakePos = Random.insideUnitSphere / 5.0f;
            transform.localPosition += shakePos;
            icf.isdou -= Time.deltaTime*2;
        }
        else
        {
            icf.isdou = 0f;
        }
    }
}
