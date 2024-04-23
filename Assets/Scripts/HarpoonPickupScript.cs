using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonPickupScript : MonoBehaviour
{
    public float rotationSpeed;

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);
    }
}
