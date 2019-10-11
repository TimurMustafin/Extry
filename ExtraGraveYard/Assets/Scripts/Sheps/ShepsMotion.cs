using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsMotion : MonoBehaviour
{
    [SerializeField]
    public ShepsSettings shepsSettings;

    private IUserInput userInput;
    private ShepsAnimation shepsAnimation;

    void Start()
    {
        userInput = GetComponent<IUserInput>();
        shepsAnimation = GetComponent<ShepsAnimation>();
    }

    void Update()
    {
        if (shepsAnimation.IsDying) return;

        userInput.ReadUserInput();
        
        if (shepsAnimation.IsRunning)
            Move(2);
        else
            Move(1);
    }

    private void Move(int SpeedFactor)
    {
        Vector3 direction = transform.forward * userInput.Translation + transform.right * userInput.Rotation;

        if (direction.magnitude != 0)
        {
            if (userInput.Translation != 0)
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(direction), shepsSettings.DampRotateForMove * Time.deltaTime);
            }
            else
            {
                transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.LookRotation(direction), shepsSettings.DampRotateForRest * Time.deltaTime);
            }
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(transform.forward), shepsSettings.DampRotateForMove * Time.deltaTime);
        }

        transform.position += transform.forward * userInput.Translation * shepsSettings.MoveSpeed * SpeedFactor * Time.deltaTime;
    }

   
}
