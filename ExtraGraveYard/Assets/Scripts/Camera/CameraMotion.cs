using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion : MonoBehaviour
{
    [SerializeField]
    public Transform target;
    [SerializeField]
    public Vector3 offset;
    [SerializeField]
    public float Damp;


    
    void Update()
    {
        transform.LookAt(target);
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Damp * Time.deltaTime);
        

    }
}
