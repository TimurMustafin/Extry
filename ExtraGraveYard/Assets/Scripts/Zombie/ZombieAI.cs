
using UnityEngine;
using UnityEngine.AI;

public class ZombieAI : MonoBehaviour
{
    NavMeshAgent agent;
    Transform currentTarget;
    ZombieAnimation zombieAnimation;
    bool isKillingHuman;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        zombieAnimation = GetComponent<ZombieAnimation>();
        PointOfInterest.OnEnterPoint += (Transform target) => { currentTarget = target; };
    }


    void Update()
    {
        if (isKillingHuman) return;
       
        if (currentTarget && !agent.pathPending)
        {
            agent.SetDestination(currentTarget.position);
            transform.LookAt(currentTarget);

            if (zombieAnimation.IsRunning)
                agent.velocity = agent.desiredVelocity * 2;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Sheps")
        {
            isKillingHuman = true;
            agent.isStopped = true;
        }
    }


}
