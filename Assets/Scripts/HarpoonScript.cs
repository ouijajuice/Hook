using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonScript : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    public GameObject fleshHarpoon;
    public GameObject fleshExplosion;
    public Transform lineEndPoint;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject lineObject = GameObject.FindWithTag("MainCamera");
        LineRendererScript lineScript = lineObject.GetComponent<LineRendererScript>();
        lineScript.pos2 = lineEndPoint;
        rb.AddForce(transform.up * speed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 10f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(fleshHarpoon, transform.position, transform.rotation);
            Instantiate(fleshExplosion, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
            //Debug.Log("Hit Enemy");
        }
        else if (collision.gameObject.CompareTag("Grappleable"))
        {
            //Debug.Log("Hit Grapple");
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
        }
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
