using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sens;
    public Transform playerBody;

    float xRotation;
    //float yRotation;

    public LayerMask nonHitLayer;

    public GunRotateToPoint gunRotateScript;

    public string enemyTag;
    public string grappleTag;

    public Transform hitPoint;
    public Transform defaultHitPoint;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        nonHitLayer = ~nonHitLayer;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        float mouseX = Input.GetAxisRaw("Mouse X") * sens;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sens;

        playerBody.Rotate(Vector3.up * mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                hitPoint.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            if (!hit.collider)
            {
                hitPoint = defaultHitPoint;
                Debug.Log("No Target");
            }

            gunRotateScript.target = hitPoint;

            if (hit.collider.gameObject.CompareTag(enemyTag))
            {
                //Debug.Log("Hit Enemy");
            }
            else if (hit.collider.gameObject.CompareTag(grappleTag))
            {
                //Debug.Log("Hit Grapple");
            }

            hitPoint = defaultHitPoint;
        }
    }
}