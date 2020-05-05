using UnityEngine;
using System.Collections;

public class CamShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    public Transform camTransform;

    public float shakeDurationTotal = 0f;
	
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.7f;

    Vector3 originalPos;
    public static bool shakingNow = false;

	
    void Awake()
    {
        if (camTransform == null)
        {
            camTransform = Camera.main.GetComponent(typeof(Transform)) as Transform;
        }
        
        originalPos = camTransform.position;
    }

    void Update()
    {
        
        if (shakingNow)
        {
            CamShaking();
        }
        else
        {
            camTransform.localPosition = originalPos;
        }
    }

    void CamShaking()
    {
        camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
    }
}