using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using static Unity.Mathematics.math;

public class ScreamModifier : MonoBehaviour
{
    private AudioManager _audioManager;
    private TouchTracker _touchTracker;

    private Camera cam;

    private Vector3 screenPos;

    private float screenXEndPoint;
    private float screenXStartPoint;

    private Vector4 screenCoordinates;

    private float playerXPos;
    private float playerYPos;

    private ScreamModifier instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _touchTracker = FindObjectOfType<TouchTracker>();

        cam = Camera.main;
    }
    
    void Update()
    {
        PositionUpdate();
        TrackPlayerInteraction();
    }

    void TrackPlayerInteraction()
    {
        if (GameManager.currentScene == GameManager.ExistingScenes.voice)
        {
            ChangePitch();
            ChangeVolume();
        }
    }

    void ChangePitch()
    {
        float pitchValue = remap(0, 1, 0.8f, 1.7f, playerXPos);
        _audioManager.AdjustPitch(pitchValue);
    }
    

    void ChangeVolume()
    {
//        Debug.Log(playerYPos);
        float volumeValue = remap(0, 1, 0.2f, 1.2f, playerYPos );
        _audioManager.AdjustVolume(volumeValue);
    }

    void PositionUpdate()
    {
        playerXPos = _touchTracker.playerPosNormalized().x;
        playerYPos = _touchTracker.playerPosNormalized().y;
    }
}
