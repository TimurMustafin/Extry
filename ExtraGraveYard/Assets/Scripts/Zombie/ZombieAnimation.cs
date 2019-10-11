using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    public float InRange;
    public float OutRange;
    
    private Animator zombieAnimator;
    private Transform currentTarget;
    private bool isRunning;
    private bool isAttack;
    private bool isResting;

    public bool IsRunning { get => isRunning;}
    public bool IsAttack { get => isAttack; }
    public bool IsResting { get => isResting; }

    void Start()
    {
        zombieAnimator = GetComponent<Animator>();
        PointOfInterest.OnEnterPoint += (Transform target) => 
        {
            currentTarget = target;
            zombieAnimator.SetFloat("Speed", 1f);
        };
    }

    void Update()
    {
        if (currentTarget)
        {
            float distance = (currentTarget.position - transform.position).magnitude;
            if (distance < InRange)
            {
                isRunning = true;
                zombieAnimator.SetBool("Run", isRunning);
            }
            if (distance > OutRange)
            {
                isRunning = false;
                zombieAnimator.SetBool("Run", isRunning);
                zombieAnimator.SetBool("IdleAfterRun", true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Sheps")
        {
            isAttack = true;
            zombieAnimator.SetBool("Attack", isAttack);
        }
    }
}
