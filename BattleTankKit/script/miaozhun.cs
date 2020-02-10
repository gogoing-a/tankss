using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miaozhun : MonoBehaviour
{
    public float zoomLevel = 2.0f;
    public float zoomInSpeed = 100.0f;
    public float zoomOutSpeed = 100.0f;

    private float initFOV;
    private bool iskai = false;
    void Start()
    {
        //获取当前摄像机的视野范围 unity默认值60
        initFOV = Camera.main.fieldOfView;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)&&iskai==false)
        {
            //ZoomInView();
            //激活ui窗口
            Camera.main.fieldOfView = 30;
            iskai = true;
        }
        else if(Input.GetMouseButtonDown(1)&&iskai==true)
        {
            //ZoomOutView();
            Camera.main.fieldOfView = 60;
            iskai = false;
        }

    }

    ////放大摄像机的视野区域
    //void ZoomInView()
    //{
    //    if (Mathf.Abs(Camera.main.fieldOfView - (initFOV / zoomLevel)) < 0f)
    //    {
    //        Camera.main.fieldOfView = initFOV / zoomLevel;
    //    }
    //    else if (Camera.main.fieldOfView - (Time.deltaTime * zoomInSpeed) >= (initFOV / zoomLevel))
    //    {
    //        Camera.main.fieldOfView -= (Time.deltaTime * zoomInSpeed);
    //    }
    //}

    ////缩小摄像机的视野区域
    //void ZoomOutView()
    //{
    //    if (Mathf.Abs(Camera.main.fieldOfView - initFOV) < 0f)
    //    {
    //        Camera.main.fieldOfView = initFOV;
    //    }
    //    else if (Camera.main.fieldOfView + (Time.deltaTime * zoomOutSpeed) <= initFOV)
    //    {
    //        Camera.main.fieldOfView += (Time.deltaTime * zoomOutSpeed);
    //    }
    //}

}
