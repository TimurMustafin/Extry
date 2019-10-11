using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShepsFireBall : MonoBehaviour
{
    public GameObject fireBallPref;

    public GameObject GetFireBall()
    {
        GameObject fireBall = Instantiate(fireBallPref, transform.position, Quaternion.identity);
        return fireBall;

    }
}
