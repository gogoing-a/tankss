using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public UIjoysticks uijoysticks;
    public Vector2 StarPostion;
    public Vector2 NewPostion;
    public bool startPosFlag;
    public Transform jos;
    public float distance;
    public GameObject gans;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        startPosFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        float hor = uijoysticks.Horizontal;
        float ver = uijoysticks.Vertical;

        Vector3 direction = new Vector3(hor, 0, ver);

        if (direction != Vector3.zero)
        {
            //控制转向
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 10);
            //向前移动
            transform.Translate(Vector3.forward * Time.deltaTime * 5);
        }
        distance = Vector3.Distance(StarPostion, jos.position);
        MobileMove();     
    }

    public void MobileMove()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(i).phase == TouchPhase.Began && startPosFlag == true)
                {                   
                    StarPostion = Input.GetTouch(i).position;
                    startPosFlag = false;
                }
                if (Input.GetTouch(i).phase == TouchPhase.Ended && startPosFlag == false)
                {

                    startPosFlag = true;
                }
                NewPostion = Input.GetTouch(i).position;
            }
            if (distance > 200)
            {
                if (Input.touchCount > 0 && Input.GetTouch(i).phase == TouchPhase.Moved)
                {
                    //右
                    if (Mathf.Abs(NewPostion.x - StarPostion.x) > Mathf.Abs(NewPostion.y - StarPostion.y))
                    {
                        if (NewPostion.x - StarPostion.x > 0)
                        {
                            
                            gans.transform.Rotate(Vector3.down * Time.deltaTime * 200);

                        }
                        else
                        {
                            //左
                            
                            gans.transform.Rotate(Vector3.up * Time.deltaTime * 200);
                        }
                    }
                    else
                    {
                        //上
                        if (NewPostion.y - StarPostion.y > 0)
                        {

                            bullet.transform.Rotate(Vector3.right * Time.deltaTime * 200);
                        }
                        else
                        {

                            //下
                            bullet.transform.Rotate(Vector3.left * Time.deltaTime * 200);
                        }
                    }
                }
            }
        }
    }
}
