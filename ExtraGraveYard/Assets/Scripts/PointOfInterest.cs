using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointOfInterest : MonoBehaviour
{
    public static event Action<Transform> OnEnterPoint;


    void Start()
    {

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sheps")
        {
            OnEnterPoint(other.gameObject.transform);
        }
        
    }
}
