using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed;
    Rigidbody rb;
    NavMeshAgent agent;
    public float viewDistance;
    public float wanderDistance;
    public Animator animator;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        agent.speed = speed;
        if (agent.velocity.magnitude == 0)
        {
            animator.Play("Idle");
        }
        else if (agent.velocity.magnitude < 3)
        {
            animator.Play("Walk");
        }
        else
        {
            animator.Play("Run");
        }

        var distance = Vector3.Distance(transform.position, target.position);
        if(distance < viewDistance)
        {
            //see
            agent.destination = target.position;
        }
        else
        {
            //dont see
            if(agent.velocity == Vector3.zero)
            {
                var offset = Random.insideUnitSphere * wanderDistance;
                agent.destination = transform.position + offset;
            }
            if(distance < 1f)
            {
                //jumpscare
            }
        }
    }
}
