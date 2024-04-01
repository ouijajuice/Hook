using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmSwing : MonoBehaviour
{
    [SerializeField]
    float startYRotation;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.transform
        transform.rotation.y = startYRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
