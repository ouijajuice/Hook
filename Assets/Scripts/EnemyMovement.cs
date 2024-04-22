using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.Animations;

public class EnemyMovement : MonoBehaviour
{
    public Transform target;
    public float detectionRadius;
    public LayerMask playerLayer;
    private Rigidbody rb;
    private NavMeshAgent agent;
    private bool detectedPlayer = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    
    //}

    private void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, detectionRadius, playerLayer))
        {
            detectedPlayer = true;
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform;
            //Debug.Log("Detected player");
        }
        else
        {
            detectedPlayer = false;
        }
        if (detectedPlayer)
        {
            animator.SetBool("walking", true);
            agent.SetDestination(target.position);
        }
        if (transform.position == agent.destination)
        {
            animator.SetBool("walking", false);
        }
    }
}
