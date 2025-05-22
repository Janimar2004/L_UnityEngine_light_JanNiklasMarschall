using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lightflicker : MonoBehaviour
{
    public float minIntensity = .5f;
    public float maxIntensity = 2f;
    public float flickerSpeed = 2.0f;
    private void Update()
    {
        float noise = Mathf.PerlinNoise(1, Time.time * flickerSpeed);
        GetComponent<Light>().intensity = Mathf.Lerp(minIntensity, maxIntensity, noise);

        transform.rotation = Quaternion.Euler(0, noise, 0);
    }
}
