using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleshHarpoonScript : MonoBehaviour
{
    public float speed;
    private GameObject firePoint;
    private Transform target;
    private bool inAir = true;
    private void Start()
    {
        firePoint = GameObject.FindWithTag("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        if (firePoint != null && inAir)
        {
            target = firePoint.transform;

            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            transform.rotation = target.rotation;
            if (transform.position == target.position)
            {
                transform.SetParent(target.gameObject.transform);
            }
        }
        

    }
}
