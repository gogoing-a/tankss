using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ranking : MonoBehaviour
{

    private Transform targePos;//跟随的目标
    private Vector3 offsetPos;//固定位置
    private Vector3 temPos;//临时变量
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3(0, distance, 0);
    }

    // Update is called once per frame
    void Update()
    {
        targePos = GameObject.FindGameObjectWithTag("dian").transform;
        temPos = targePos.position + targePos.TransformDirection(offsetPos);
        transform.position = Vector3.Lerp(transform.position, temPos, Time.fixedDeltaTime * 3);
        //transform.LookAt(targePos);
    }
}
