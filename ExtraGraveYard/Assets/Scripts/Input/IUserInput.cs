using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUserInput
{
    float Translation { get;}
    float Rotation { get; }

    void ReadUserInput();
}
