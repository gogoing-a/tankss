using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logfollow : MonoBehaviour
{
    private Transform targePos;//跟随的目标
    private Vector3 offsetPos;//固定位置
    private Vector3 temPos;//临时变量
    // Start is called before the first frame update
    void Start()
    {
        offsetPos = new Vector3(0, 10f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
