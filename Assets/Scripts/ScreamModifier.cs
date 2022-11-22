using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamModifier : MonoBehaviour
{
    private AudioManager _audioManager;
    private TouchTracker _touchTracker;

    private Camera cam;

    private Vector3 screenPos;

    private float screenXEndPoint;
    private float screenXStartPoint;

    private Vector4 screenCoordinates;
    
    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _touchTracker = FindObjectOfType<TouchTracker>();
        
        cam = Camera.main;
    }
    
    void Update()
    {
        Debug.Log(_touchTracker.playerPos());

    }
}
