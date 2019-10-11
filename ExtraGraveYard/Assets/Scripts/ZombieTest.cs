using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieTest : MonoBehaviour
{

    Animator animator;
    NavMeshAgent navMeshAgent;
    Transform target;
    public float Range;

    private void Start()
    {
        animator = GetComponent<Animator>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        PointOfInterest.OnEnterPoint += ZombieFeelMan;

    }

    void ZombieFeelMan(Transform currentTarget)
    {
        target = currentTarget;

        animator.SetFloat("Speed", 1);
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target.transform);

            if (!navMeshAgent.pathPending)
                navMeshAgent.SetDestination(target.transform.position);

            if ((target.transform.position - transform.position).magnitude < Range)
                animator.SetBool("Run", true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Player")
        {
            animator.SetBool("Attack", true);
        }    
    
    }

    
}
