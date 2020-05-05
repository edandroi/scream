using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScream : MonoBehaviour
{

    public void Start()
    {
        transform.position = new Vector3(0, - Manager.screenDimensions.y + Manager.screenDimensions.y * 1/3, 0 );
    }

    private void OnMouseDown()
    {
        Manager.isScreaming = true;
        Player.isScreaming = true;
        CamShake.shakingNow = true;
    }

    private void OnMouseUp()
    {
        Manager.isScreaming = false;
        Player.isScreaming = false;
        CamShake.shakingNow = false;
    }
}
