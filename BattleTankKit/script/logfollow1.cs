using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logfollow1 : MonoBehaviour
{
    public GameObject log;
    public tankHp thp;
    private Transform targePos;//跟随的目标
    private Vector3 offsetPos;//固定位置
    private Vector3 temPos;//临时变量
    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3(0, 50f, 0f);
        this.transform.Rotate(transform.right * 90);
    }

    // Update is called once per frame
    void Update()
    {
        if (log != null)
        {
            this.gameObject.transform.position = log.transform.position + offsetPos;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
