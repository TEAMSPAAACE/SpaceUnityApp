using UnityEngine;
using System.Collections;

public class RedLights : MonoBehaviour {
    
    private const float pulseRange = 4.0f;
    private const float pulseSpeed = 3.0f;
    private Light redLight;

    void Start()
    {
        redLight = GetComponent<Light>();
	}
	
	void Update()
    {
        redLight.range = Mathf.PingPong(Time.time* pulseSpeed, pulseRange);
    }
}
