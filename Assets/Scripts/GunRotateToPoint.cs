using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotateToPoint : MonoBehaviour
{
    public Transform target;

    public float speed = 1.0f;

    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        //Debug.DrawRay(transform.position, newDirection, Color.red, 10f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
