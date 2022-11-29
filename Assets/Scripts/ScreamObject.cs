using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamObject : MonoBehaviour
{
    private SpriteRenderer m_Renderer;

    private Vector3 finalScale;

    private TouchTracker _touchTracker;

    float minScale = 1f;
    float maxScale = 2f;

    public float scalingSpeed = 1f;

    private float target;
    
    float timerDestroy;

    void Start()
    {
        _touchTracker = FindObjectOfType<TouchTracker>();
        transform.localScale = Vector3.zero;
        m_Renderer = GetComponent<SpriteRenderer>();
        
        float scaler = Random.Range(minScale, maxScale)*_touchTracker.playerPosNormalized().y;
        scaler = Mathf.Clamp(scaler, 0.2f, 3f);
        finalScale = new Vector3(scaler, scaler, 1);

        target = scaler - .05f;
        
        scalingSpeed *= _touchTracker.playerPosNormalized().x;
        scalingSpeed = Mathf.Clamp(scalingSpeed, 0.05f, 0.8f);

        timerDestroy = Random.Range(.4f, 1.4f);
        
        Vector3 euler = transform.eulerAngles;
        euler.z = Random.Range(-10f, 10f);
        transform.eulerAngles = euler;
    }

    void Update()
    {
        if (transform.localScale.x < target)
        {
            float currentScale = transform.localScale.x;
            currentScale = Mathf.Lerp(currentScale, target, scalingSpeed);
            transform.localScale = new Vector3(currentScale, currentScale, 1);
        }

        if (transform.localScale.x > target - .01f)
        {
            if (GameManager.isScreaming)
            {
                timerDestroy -= Time.deltaTime;
            }
            else
            {
                timerDestroy -= Time.deltaTime*2.5f;
                
            }
            
            if (timerDestroy < 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
