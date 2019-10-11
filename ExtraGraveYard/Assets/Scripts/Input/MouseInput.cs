using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour, IUserInput
{
    public float Translation { get; private set; }
    public float Rotation { get; private set; }

    public void ReadUserInput()
    {
        Translation = Mathf.Clamp( Input.GetAxis("Mouse Y"), 0, 1);
        Rotation = Input.GetAxis("Mouse X");
    }
}
