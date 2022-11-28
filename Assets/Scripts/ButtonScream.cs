using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonScream : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private AudioManager _audioManager;
    private Button screamButton;
    
    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        screamButton = gameObject.GetComponent<Button>();
    }
    
    public void ScreamTrue()
    {
        GameManager.isScreaming = true;
        Player.isScreaming = true;
        CamShake.shakingNow = true;
    }

    public void ScreamFalse()
    {
        GameManager.isScreaming = false;
        Player.isScreaming = false;
        CamShake.shakingNow = false;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameManager.currentScene == GameManager.ExistingScenes.voice)
            _audioManager.PlayScream();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (GameManager.currentScene == GameManager.ExistingScenes.voice)
            _audioManager.StopScream();
    }
}
