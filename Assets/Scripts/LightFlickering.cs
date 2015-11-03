using UnityEngine;
using System.Collections;

public class LightFlickering : MonoBehaviour
{

    public float flickerDelay = 0.5f;
    public float minIntensity = 0f;
    public float maxIntensity = 3f;
    public float smoothAmount = .5f;

    float prevFlicker = 0f;
    public Light[] flickerLights;

    public bool flickeringActive = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (flickeringActive && Time.time > prevFlicker + flickerDelay)
        {
            float lightIntensity = Random.Range(minIntensity, maxIntensity);
            prevFlicker = Time.time;
            foreach (Light l in flickerLights)
            {
                l.intensity = Mathf.Lerp(l.intensity, lightIntensity, smoothAmount);
            }
        }
        else
        {
            foreach (Light l in flickerLights)
            {
                l.intensity = maxIntensity;
            }
        }
    }
}