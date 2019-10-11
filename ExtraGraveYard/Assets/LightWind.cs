using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWind : MonoBehaviour
{
    private Light windyLight;
    private float startIntensity;

    void Start()
    {
        windyLight = GetComponent<Light>();
        startIntensity = windyLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        windyLight.intensity = startIntensity + Random.Range(-0.5f, 0.5f); 
    }
}
