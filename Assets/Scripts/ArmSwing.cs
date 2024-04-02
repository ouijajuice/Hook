using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwing : MonoBehaviour
{
    //[SerializeField]
    Vector3 startYRotation;
    private Transform trans;
    [SerializeField]
    Vector3 rotationChange;
    [SerializeField]
    float rotationSpeed;
    private bool swinging = false;
    // Start is called before the first frame update
    void Start()
    {
        trans = GetComponent<Transform>();
        startYRotation = trans.localEulerAngles;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            swinging = true;
        }
        
        if (swinging)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            //trans.Rotate(rotationChange * rotationSpeed * Time.deltaTime);
            transform.Rotate(Vector3.up, rotationAmount);
            if (Mathf.Abs(transform.rotation.eulerAngles.y) >= 170f)
            {
                transform.rotation = Quaternion.Euler(startYRotation);
                swinging = false;
            }
        }

        //if (trans.rotation.y < 0f)
        //{
        //    trans.rotation = Quaternion.Euler(startYRotation);
        //    swinging = false;
        //}

    }
}
