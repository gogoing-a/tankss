using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TanksMove : MonoBehaviour
{
    public GameObject yidong;
    public float TankSpeed = 5;
    public string[] TargetTag = { "Player" };
    public NavMeshAgent mesh;
    public float TurnSpeed = 20;

    private Vector3 positionTemp;
    private int islive;
    private int state=1000;
    private float raomdoZ = 0;
    private float raomdoX = 0;
    private int TankStatetion=0;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        souchTartag();
        MoveTo();
        positionTemp = this.transform.position;
        switch (state)
        {
            case 0:
                islive = Random.Range(0, 100);
                if (islive<=30&&TankStatetion==0)
                {
                   
                    TankStatetion = 1;
                }
                //mesh.transform.Rotate(0,25,0);
                break;
            default:
                break;
        }
    }

    public void MoveTo()
    {
        // This tank move along with navigator object.
        Quaternion rotationTarget = this.transform.rotation;
        rotationTarget.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotationTarget.eulerAngles.y, this.transform.eulerAngles.z);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationTarget, TurnSpeed * 0.1f * Time.deltaTime);
        positionTemp = this.transform.position;
        this.transform.position += this.transform.forward * TankSpeed * Time.deltaTime;
        // Track animation working
        // increase Pitch when moving
    }


    void souchTartag()
    {
        if (Vector3.Distance(this.transform.position, yidong.transform.position) > 0)
        {
            this.transform.position = new Vector3(yidong.transform.position.x, yidong.transform.position.y, yidong.transform.position.z);
            this.transform.rotation = yidong.transform.rotation;
            for (int i = 0; i < TargetTag.Length; i++)
            {
                GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag[i]);
                for (int j = 0; j < targets.Length; j++)
                {
                    float dot = Vector3.Dot(this.transform.forward, targets[j].transform.forward);
                    float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;
                    Debug.Log(angle);
                    float distance = Vector3.Distance(this.gameObject.transform.position, targets[j].transform.position);
                    if (distance < 50)
                    {
                        state = 0;
                        raomdoZ = Random.Range(-50, 0);
                        raomdoX = Random.Range(-50, 0);

                        //yidong.transform.Translate(new Vector3( Time.deltaTime * TankSpeed, 0, Time.deltaTime * TankSpeed));
                    }
                }
            }
        }
    }
}