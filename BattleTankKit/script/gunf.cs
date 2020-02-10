using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunf : MonoBehaviour
{

    public GameObject Turret;
    public GameObject MainGun;
    public Vector3 TurretBaseAxis = new Vector3(0, 1, 0);
    public Vector3 MainGunBaseAxis = new Vector3(1, 0, 0);
    public float TurretSpeed = 20;

    public float MaingunMinTurnX = -30;
    public float MaingunMaxTurnX = 45;


    public float FlipRatio = 0.7f;
    private float rotationX = 0;

    private Vector3 turrentEulerAngle;
    private Vector3 maingunEulerAngle;
    // Start is called before the first frame update
    void Start()
    {
        if (Turret != null)
        {
            turrentEulerAngle = Turret.transform.localEulerAngles;
        }
        if (MainGun != null)
        {
            maingunEulerAngle = MainGun.transform.localEulerAngles;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Aim(Vector2 aimVector)
    {
        // aim with cursor vector
        if (Turret != null)
        {
            float rotationY = Turret.transform.localEulerAngles.y + aimVector.x * TurretSpeed * Time.deltaTime;
            Turret.transform.localEulerAngles =
                new Vector3(
                (TurretBaseAxis.x * rotationY) + ((1 - TurretBaseAxis.x) * turrentEulerAngle.x),
                (TurretBaseAxis.y * rotationY) + ((1 - TurretBaseAxis.y) * turrentEulerAngle.y),
                (TurretBaseAxis.z * rotationY) + ((1 - TurretBaseAxis.z) * turrentEulerAngle.z)
            );

        }
        if (MainGun != null)
        {
            rotationX += aimVector.y * TurretSpeed * Time.deltaTime;
            rotationX = Mathf.Clamp(rotationX, MaingunMinTurnX, MaingunMaxTurnX);

            MainGun.transform.localEulerAngles =
            new Vector3(
                (MainGunBaseAxis.x * -rotationX) + maingunEulerAngle.x,
                (MainGunBaseAxis.y * -rotationX) + maingunEulerAngle.y,
                (MainGunBaseAxis.z * -rotationX) + maingunEulerAngle.z
            );
        }
    }
}