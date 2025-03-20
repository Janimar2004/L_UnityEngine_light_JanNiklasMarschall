using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LightIntensityAndColorController : MonoBehaviour
{
    
    [SerializeField] private GameObject[] pointLights;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private float maxIntenity = 5f;

    public Color startColor = Color.red;
    public Color endColor = Color.green;

    void Start()
    {
        pointLights = GameObject.FindGameObjectsWithTag("pointLight");
        
    }

    void Update()
    {
        foreach(GameObject LightObject in pointLights)
        {
            Light pointLight = LightObject.GetComponent<Light>();
            pointLight.intensity = 20;
            float distance = Vector3.Distance(pointLight.transform.position, transform.position);
            float intensity = (1 - distance / maxDistance) * maxIntenity;

            if (distance < maxDistance )
            {
                pointLight.intensity = intensity;

                float colorRatio = 1 - (distance / maxDistance);

                pointLight.color = Color.Lerp(startColor, endColor, intensity);
            }
            else
            {
                pointLight.intensity = 0;
                pointLight.color = startColor;
            }
        }
    }
}
