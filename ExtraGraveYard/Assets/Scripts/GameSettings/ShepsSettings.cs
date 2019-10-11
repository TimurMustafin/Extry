using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Sheps Settings")]
public class ShepsSettings : ScriptableObject
{
    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float dampRotateForMoving;
    [SerializeField]
    public float dampRotateForRest;
    [SerializeField]
    public float fireBallSpeed;
    [SerializeField]
    public int fireBallAmount;

    public float MoveSpeed { get => moveSpeed; }
    public float DampRotateForMove { get => dampRotateForMoving; }
    public float DampRotateForRest { get => dampRotateForRest; }
    public float FireBallSpeed { get => fireBallSpeed; }
    public int FireBallAmount { get => FireBallAmount; }
}
