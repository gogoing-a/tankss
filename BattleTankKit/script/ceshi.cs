using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(NpcGun))]
public class ceshi : MonoBehaviour
{

    public float TankSpeed = 10;
    public float TurnSpeed = 20;   
    public float StopDistance = 2;
    public daohang Mesh;
    public int PatrolDistance = 100;
    public float FireDistance = 20;
    public string[] TargetTag = { "Player" };
    public int PatrolDurationMax = 15;
    public GameObject gun;
    public GameObject MainGun;
    public Vector3 TurretBaseAxis = new Vector3(0, 1, 0);
    public Vector3 MainGunBaseAxis = new Vector3(1, 0, 0);
    public float TurretSpeed = 20;
    public int FiringSpread = 500;
    public float AimingAngle;
    public bool canFire = false;
    public float MaingunMinTurnX = -10;
    public float MaingunMaxTurnX = 45;


    private float rotationX = 0;
    private float FiringDelay = 5;
    private float aiFireDelay = 0;
    private NpcGun npc;
    private Vector3 aimAround;
    private Vector3 turrentEulerAngle;
    private Vector3 maingunEulerAngle;
    private daohang mesh;
    private GameObject currentTarget;
    private float aiTime = 0;
    private int aiMoveState = 0;
    private Vector3 positionTemp;
    private Vector3 positionAround;
    // Start is called before the first frame update


    void Awake()
    {
        npc = GetComponentInChildren<NpcGun>();
    }


    void Start()
    {
        positionTemp = this.transform.position;
        if (Mesh != null)
        {
            GameObject navigatorObj = (GameObject)GameObject.Instantiate(Mesh.gameObject, this.transform.position, Mesh.transform.rotation);
            mesh = navigatorObj.GetComponent<daohang>();
            mesh.Navigator.speed = TankSpeed;
            mesh.Owner = this.gameObject;
        }

        if (gun != null)
        {
            turrentEulerAngle = gun.transform.localEulerAngles;
        }
        if (MainGun != null)
        {
            maingunEulerAngle = MainGun.transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPoint = Vector3.Distance(this.transform.position, positionAround);
        if (currentTarget == null)
        {
           
            if (aiTime <= 0)
            {
                aiMoveState = 0;
            }
            else
            {
                aiTime -= 1 * Time.deltaTime;
            }


            switch (aiMoveState)
            {
                case 0:
                    positionAround = DetectGround(this.transform.position + new Vector3(Random.Range(-PatrolDistance, PatrolDistance), 10000, Random.Range(-PatrolDistance, PatrolDistance)));
                    aiMoveState = 1;
                    aiTime = Random.Range(0, PatrolDurationMax);
                    break;
                case 1:
                    if (Vector3.Distance(mesh.transform.position, this.transform.position) > 1)
                    {
                        mesh.transform.position = this.transform.position;
                    }
                    if (distanceToPoint > StopDistance)
                    {
                        mesh.SetDestination(positionAround);
                        MoveTo(mesh);
                    }
                    Ami(positionAround);
                    break;
            }
            FindNewTarget();
        }
        else
        {
            float targetDistance = Vector3.Distance(this.transform.position, currentTarget.transform.position);
            Vector3 targetDirection = (currentTarget.transform.position - this.transform.position).normalized;

            RaycastHit hit;

            if (Physics.Raycast(currentTarget.transform.position + Vector3.up - (targetDirection * 2), -targetDirection, out hit))
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    if (targetDistance <= FireDistance)
                    {
                        canFire = true;
                    }
                }
            }

            switch (aiMoveState)
            {
                case 0:
                    aimAround = (new Vector3(Random.Range(-FiringSpread, FiringSpread), Random.Range(0, FiringSpread) + targetDistance, Random.Range(-FiringSpread, FiringSpread))) * 0.001f;
                    positionAround = currentTarget.transform.position + new Vector3(Random.Range(-FireDistance, FireDistance), 0, Random.Range(-FireDistance, FireDistance));
                    aiMoveState = 1;
                    Debug.Log("sdasda");
                    aiTime = Random.Range(0, PatrolDurationMax);
                    break;
                case 1:
    
                    break;
            }
            if (!canFire||distanceToPoint > FireDistance / 2)
            {
                mesh.SetDestination(positionAround);
                MoveTo(mesh);
                if (Vector3.Distance(mesh.transform.position, this.transform.position) > 1)
                {
                    mesh.transform.position = this.transform.position;
                }
            }
            Ami(currentTarget.transform.position + aimAround);

            if(canFire&& AimingAngle<5)
            {
                if (aiFireDelay <= 0)
                {
                    aiFireDelay = Random.Range(0, FiringDelay);
                    npc.shoot();
                }
                else
                {                   
                    aiFireDelay -= 1 * Time.deltaTime;
                }
            }

            if(AimingAngle > 20)
            {
                npc.StopAllCoroutines();
            }

            if (aiTime <= 0)
            {
                aiMoveState = 0;
                FindNewTarget();
            }
            else
            {
                aiTime -= 1 * Time.deltaTime;
            }
        }

        void MoveTo(daohang a)
        {
            // This tank move along with navigator object.
            Quaternion rotationTarget = a.transform.rotation;
            rotationTarget.eulerAngles = new Vector3(this.transform.eulerAngles.x, rotationTarget.eulerAngles.y, this.transform.eulerAngles.z);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotationTarget, TurnSpeed * 0.1f * Time.deltaTime);
            positionTemp = this.transform.position;
            this.transform.position += this.transform.forward * TankSpeed * Time.deltaTime;
            // Track animation working
            // increase Pitch when moving
        }
        
        Vector3 DetectGround(Vector3 position)
        {
            RaycastHit hit;
            if (Physics.Raycast(position, -Vector3.up, out hit, float.MaxValue))
            {
                return hit.point;
            }
            return position;
        }
    
        void FindNewTarget()
        {
            currentTarget = null;
            for (int i = 0; i < TargetTag.Length; i++)
            {
                GameObject[] targets = GameObject.FindGameObjectsWithTag(TargetTag[i]);
                float closerDistance = float.MaxValue;
                for (int t = 0; t < targets.Length; t++)
                {
                    if (targets[t] != null && targets[t] != this.gameObject)
                    {
                        float distance = Vector3.Distance(this.gameObject.transform.position, targets[t].transform.position);
                        if (distance < closerDistance)
                        {
                            currentTarget = targets[t];
                            closerDistance = distance;
                        }
                    }
                }
            }
        }
    }

    public void Ami(Vector3 target) 
    {
        float aimAngleTurret = 0;
        float aimAngleMaingun = 0;
        if (gun != null)
        {
            Vector3 localTarget = gun.transform.parent.InverseTransformPoint(target);
            Quaternion targetlook = Quaternion.LookRotation(localTarget - gun.transform.localPosition);

            targetlook.eulerAngles =
            new Vector3(
                (TurretBaseAxis.x * targetlook.eulerAngles.y) + ((1 - TurretBaseAxis.x) * turrentEulerAngle.x),
                (TurretBaseAxis.y * targetlook.eulerAngles.y) + ((1 - TurretBaseAxis.y) * turrentEulerAngle.y),
                (TurretBaseAxis.z * targetlook.eulerAngles.y) + ((1 - TurretBaseAxis.z) * turrentEulerAngle.z)
            );

            gun.transform.localRotation = Quaternion.Lerp(gun.transform.localRotation, targetlook, TurretSpeed * Time.deltaTime * 0.1f);
            aimAngleTurret = Quaternion.Angle(gun.transform.localRotation, targetlook);
        }

        if (MainGun != null && aimAngleTurret < 3)
        {

            Vector3 localTarget = MainGun.transform.parent.InverseTransformPoint(target);
            float distance = Vector2.Distance(new Vector2(localTarget.x, localTarget.z), new Vector2(MainGun.transform.localPosition.x, MainGun.transform.localPosition.z));
            float angle = Mathf.Atan(distance / localTarget.y) * Mathf.Rad2Deg;
            if (target.y < MainGun.transform.position.y)
            {
                angle = -angle;
            }
            Quaternion targetlook = MainGun.transform.localRotation;
            targetlook.eulerAngles = new Vector3((MainGunBaseAxis.x * angle) + maingunEulerAngle.x, (MainGunBaseAxis.y * angle) + maingunEulerAngle.y, (MainGunBaseAxis.z * angle) + maingunEulerAngle.z);
            MainGun.transform.localRotation = Quaternion.Lerp(MainGun.transform.localRotation, targetlook, TurretSpeed * Time.deltaTime * 0.1f);
            aimAngleMaingun = Quaternion.Angle(MainGun.transform.localRotation, targetlook);
        }
        AimingAngle = aimAngleTurret + aimAngleMaingun;
    }
}