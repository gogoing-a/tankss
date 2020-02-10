using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class daohang : MonoBehaviour
{
   
    public NavMeshAgent Navigator;
    public GameObject Owner;
    void Start()
    {
        Navigator = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    public void SetDestination(Vector3 target)
    {
        if (Navigator)
        {
            Navigator.SetDestination(target);
        }
    }

    public Vector3 GetDirection()
    {
        if (Navigator)
        {
            return (Navigator.velocity - Owner.transform.position).normalized;
        }
        return Vector3.zero;
    }

    void Update()
    {
        if (Owner == null)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
