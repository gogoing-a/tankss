using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contro : MonoBehaviour
{

    public float movespeed = 5f;
    public float rotate = 10f;
    private TankTrackAnimation track;

    // Start is called before the first frame update
    void Start()
    {
        track = GetComponentInChildren<TankTrackAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(0, 0,v * Time.deltaTime * movespeed));
        transform.Rotate(new Vector3(0, h * Time.deltaTime * rotate*50, 0));

        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            track.MoveTrack(new Vector2(1, 0));
        }
    }


}
