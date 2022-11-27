using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchTracker : MonoBehaviour
{
    private Vector3 fingerPos;
    private Vector3 mousePos;
    private Vector3 playerInteractionPos;
    private bool isMobile = false;
    
    private Camera cam;
    
    private TouchTracker instance;

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
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            isMobile = true;
        }
        
        cam = Camera.main;
    }
    
    void Update()
    {
//        if (isMobile)
//        {
//            TrackFingerPos();
//        }
//        else
//        {
//            TrackMousePos();
//        }

        TrackMousePos();
    }

    void TrackFingerPos()
    {
        fingerPos =  Input.GetTouch(0).position;
        playerInteractionPos = fingerPos;
    }

    void TrackMousePos()
    {
        mousePos = Input.mousePosition;
        playerInteractionPos = mousePos;
    }

    public Vector2 playerPosNormalized()
    {
        /*
        if (isMobile)
        {
            Vector3 screenPos = Camera.main.ScreenToViewportPoint(fingerPos);
            playerInteractionPos = screenPos;
        }
        else
        {
            Vector3 screenPos = Camera.main.ScreenToViewportPoint(mousePos);
            playerInteractionPos = screenPos;
        }
        */

        Vector2 screenPos = Camera.main.ScreenToViewportPoint(mousePos);
        playerInteractionPos = screenPos;
        
        return playerInteractionPos;
    }
}
