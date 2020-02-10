using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIjoysticks : MonoBehaviour
{
    public Vector2 initPosition;
    public float r;
    public Transform border;
    private float horizontal = 0;
    private float vertical = 0;


    // Start is called before the first frame update
    void Start()
    {
        
        border = GameObject.Find("pd").transform;
        initPosition = GetComponentInParent<RectTransform>().position;
        r = Vector3.Distance(transform.position, border.position)+200;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = transform.localPosition.x;
        vertical = transform.localPosition.y ;
        Debug.Log(horizontal);
        Debug.Log(vertical);
    }

    public float Horizontal
    {
        get { return horizontal; }
    }

    public float Vertical
    {
        get { return vertical; }
    }

    public void OnDragIng()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Vector3.Distance(Input.GetTouch(0).position, initPosition) < r)
            {
                //虚拟键跟随鼠标
                transform.position = Input.GetTouch(0).position;
            }
            else if(Vector3.Distance(Input.GetTouch(0).position, initPosition)<350)
            {
                //计算出鼠标和原点之间的向量
                Vector2 dir = Input.GetTouch(0).position - initPosition;
                //这里dir.normalized是向量归一化的意思，实在不理解你可以理解成这就是一个方向，就是原点到鼠标的方向，乘以半径你可以理解成在原点到鼠标的方向上加上半径的距离
                transform.position = initPosition + dir.normalized * r;
            }
            else
            {
                transform.localPosition = Vector3.zero;
            }
        }
    }

    public void OnDragEnd()
    {
        //松开鼠标虚拟摇杆回到原点
        transform.localPosition = Vector3.zero;
    }

}
