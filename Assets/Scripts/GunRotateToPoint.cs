using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotateToPoint : MonoBehaviour
{
    public Transform target;

    public float speed = 1.0f;

    void Update()
    {


        //transform.LookAt(target);
        //transform.rotation.SetEulerAngles(transform.rotation.x + 90f, transform.rotation.y, transform.rotation.z);


        // Determine which direction to rotate towards
        Vector3 targetDirection = target.position - transform.position;
        
        // The step size is equal to speed times frame time.
        float singleStep = speed * Time.deltaTime;
        
        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        
        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red, 10f);
        
        // Calculate a rotation a step closer to the target and applies rotation to this object
        transform.rotation = Quaternion.LookRotation(newDirection);
        
        //transform.rotation.SetLookRotation(newDirection);
    }
}
