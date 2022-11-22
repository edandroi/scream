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
        if (isMobile)
        {
            TrackFingerPos();
        }
        else
        {
            TrackMousePos();
        }
    }

    void TrackFingerPos()
    {
        fingerPos =  Input.GetTouch(0).position;
        playerInteractionPos = fingerPos;
    }

    void TrackMousePos()
    {
        mousePos = Input.mousePosition;
        Vector3 screenPos = cam.ScreenToViewportPoint(mousePos);
        playerInteractionPos = screenPos;
    }

    public Vector3 playerPos()
    {
        return playerInteractionPos;
    }
}
