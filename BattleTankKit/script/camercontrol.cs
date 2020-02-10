using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    //public float MoveSpeed = 5.0f;
    void Start()
    {
        //transform.localEulerAngles = new Vector3(0, 0, 180);
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false ;
    }
   
    //方向灵敏度
    //public float sensitivityX = 3F;
    //public float sensitivityY = 10F;

    ////上下最大视角(Y视角)  
    //public float minimumY = -100F;
    //public float maximumY = -80F;
    //public Transform a;
        public gunf gu;

    //float rotationY = 0F;
    //public Camera ca;

    //[SerializeField] LayerMask whatIsGround;
    void Update()
    {
    //    Vector3 mousePos = Input.mousePosition;
    //    mousePos = ca.ScreenToWorldPoint(mousePos);
    //    //Debug.Log("x = " + mousePos.x + ", y = " + mousePos.y + ", z = " + mousePos.z);
    //    //根据鼠标移动的快慢(增量), 获得相机左右旋转的角度(处理X)  
    //    float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

    //    //根据鼠标移动的快慢(增量), 获得相机上下旋转的角度(处理Y)  
    //    rotationY += Input.GetAxis("Mouse Y") * sensitivityY * -1;
    //    //角度限制. rotationY小于min,返回min. 大于max,返回max. 否则返回value   
    //    rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        //总体设置一下相机角度  

        //a.transform.localEulerAngles = new Vector3(rotationY, 0, 0);
        //this.transform.localEulerAngles = new Vector3(-90, rotationX, 0);
        //this.transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime);

        //Ray ray = ca.ScreenPointToRay(Input.mousePosition);

        //Debug.Log(ray);


        //RaycastHit hitInfo;

        //if (Physics.Raycast(ray, out hitInfo, 200, whatIsGround))
        //{
        //    Vector3 target = hitInfo.point;
        //    target.y = -transform.position.y + 90;
        //    transform.LookAt(target);
        //}

        Vector2 aimVector = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        gu.Aim(aimVector);
    }
}