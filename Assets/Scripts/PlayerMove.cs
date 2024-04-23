using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody player;
    public float speed;
    public float jumpForce;
    public Transform groundCheck;
    public float groundCheckDistance;
    public WeaponSway swayScript;
    public float swayMagnitude = 1f;
    public float swayMagnitudeChange = 1f;
    public int maxHealth = 5;
    public PlayerShooting playerShooting;

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        bool grounded = Physics.Raycast(groundCheck.position, Vector3.down, groundCheckDistance);

        bool jumping = Input.GetButtonDown("Jump");

        Vector3 move = (transform.right * x + transform.forward * z).normalized;

        if (jumping && grounded)
        {
            player.AddForce(transform.up * jumpForce, ForceMode.Impulse);

        }

        swayScript.counterMultiplier = swayScript.counterMultiplierInitial + Mathf.Abs(x) + Mathf.Abs(z) * swayMagnitude;
        swayScript.swayMagnitude = swayScript.swayMagnitudeInitial + swayMagnitudeChange;

        player.position += move * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLIDING");
        if (collision.collider.CompareTag("HarpoonPickup"))
        {
            Debug.Log("Colliding");
            if (playerShooting.noHarpoon)
            {
                Debug.Log("In noHapoon statement");
                playerShooting.loaded = true;
                playerShooting.noHarpoon = false;

            }
            collision.collider.gameObject.SetActive(false);
        }
    }
}