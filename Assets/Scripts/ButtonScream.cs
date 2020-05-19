using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScream : MonoBehaviour
{

    public void ScreamTrue()
    {
        Manager.isScreaming = true;
        Player.isScreaming = true;
        CamShake.shakingNow = true;
    }

    public void ScreamFalse()
    {
        Manager.isScreaming = false;
        Player.isScreaming = false;
        CamShake.shakingNow = false;
    }
}
