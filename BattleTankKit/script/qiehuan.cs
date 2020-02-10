using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qiehuan : MonoBehaviour
{
    public Camera camera_0;
    public Camera camera_1;
    public RawImage image0;
    public RawImage image1;
    public RawImage image2;
    public Transform paokou;
    public float aa = -10.0f;
    public float bb = 20.0f;
    private bool isstar = false;
    // Start is called before the first frame update
    void Start()
    {
        image1.enabled = false;
        image2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(paokou.transform.position);
        screenPos.x -= aa;
        screenPos.y -= bb;

        if (Input.GetMouseButtonDown(1) && isstar == false)
        {
            camera_0.enabled = false;
            image0.enabled = false;
            image1.enabled = true;
            image2.enabled = true;
            isstar = true;
        }
        else if (Input.GetMouseButtonDown(1) && isstar == true)
        {
            camera_0.enabled = true;
            image0.enabled = true;
            image1.enabled = false;
            image2.enabled = false;
            isstar = false;
        }
    }
}
