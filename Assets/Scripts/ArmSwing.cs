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
            trans.Rotate(Vector3.up, rotationAmount);
            if (trans.localEulerAngles.y > 100f && trans.localEulerAngles.y < 150f)
            {
                trans.localEulerAngles = new Vector3(-16,-50,0);
                swinging = false;
            }
            
        }


    }
}
