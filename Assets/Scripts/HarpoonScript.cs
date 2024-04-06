using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonScript : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    public GameObject fleshHarpoon;
    public GameObject fleshExplosion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
