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

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        agent.speed = speed;
    }
    void Update()
    {
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
