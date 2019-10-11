using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsAnimation : MonoBehaviour
{
    private IUserInput userInput;
    private Animator animator;
    private bool isCuttingSpace;
    private bool isRunning;
    private bool isDying;
    private bool fire;

    public bool IsRunning { get => isRunning; }
    public bool IsDying { get => isDying; }
    public bool IsCuttingSpace { get => isCuttingSpace; }
    public bool Fire { get => fire; }

    private void Start()
    {
        userInput = GetComponent<IUserInput>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float speed = Mathf.Abs(userInput.Translation) + Mathf.Abs(userInput.Rotation);
        animator.SetFloat("Speed", speed);

        if (Input.GetKeyDown(KeyCode.Space) && animator.GetCurrentAnimatorStateInfo(0).IsTag("Rest"))
        {
            isCuttingSpace = !isCuttingSpace;
            fire = !fire;
            animator.SetBool("CutSpace", IsCuttingSpace);
        }

        if (IsCuttingSpace)
        {
            isCuttingSpace = !isCuttingSpace;
        }

        if (Input.GetKeyDown(KeyCode.Space) && animator.GetCurrentAnimatorStateInfo(0).IsTag("Locomotion"))
        {
            isRunning = !isRunning;
            animator.SetBool("Run", isRunning);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Zombie")
        {
            isDying = true;
            animator.SetBool("IsDying", isDying);
            
        }
    }

}
