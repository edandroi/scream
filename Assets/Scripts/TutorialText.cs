using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialText : MonoBehaviour
{
    private TextMeshProUGUI txtObj;

    public string text1 = "Tap anywhere to scream.";
    public string text2 = "Move your finger across the screen to change your voice.";

    private bool initialTap = false;

    private float timer = 0;
    private float maxTime = 6f;
    
    private TMP_Text m_TextComponent;

    void Start()
    {
        txtObj = GetComponent<TextMeshProUGUI>();
        m_TextComponent = GetComponent<TMP_Text>();
        
        m_TextComponent.text = text1;
    }

    void Update()
    {
       ChangeTextOnScreen();
    }

    public void InitialTapTrigger()
    {
        initialTap = true;
    }

    void ChangeTextOnScreen()
    {
        if (GameManager.currentScene == GameManager.ExistingScenes.voice && !GameManager.firstLoudScream
            || GameManager.currentScene == GameManager.ExistingScenes.silent && !GameManager.firstSilentScream)
        {
            if (initialTap)
            {
                if (timer < maxTime)
                {
                    txtObj.text = text2;
                    timer += Time.deltaTime;
                }
                else
                {
                    txtObj.text = " ";
                }
            }
        }
        else
        {
            if (initialTap)
                txtObj.text = " ";  
        }
    }

}
