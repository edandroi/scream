using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScreamAnalyzer : MonoBehaviour
{
    private int totalScreamDuration;

    private TextMeshProUGUI m_Text;
    
    void Start()
    {
        totalScreamDuration = Manager.totalSecs;
        
        Debug.Log(GetComponent<TextMeshProUGUI>());
        m_Text = GetComponent<TextMeshProUGUI>();

        AnalyzeScream();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowAnalyze()
    {
        
    }

    void AnalyzeScream()
    {
        int result = 0;

        if (totalScreamDuration < 2)
        {
            // mellow
            result = 0;
        }
        else if (totalScreamDuration >= 2 && totalScreamDuration < 4)
        {
            // relaxed
            result = 1;
        }
        else if (totalScreamDuration >= 4 && totalScreamDuration < 7)
        {
            // anxious
            result = 2;
        }
        else if (totalScreamDuration >= 7 && totalScreamDuration < 10)
        {
            // angry
            result = 3;
        }
        else if (totalScreamDuration >= 10)
        {
            // troubled
            result = 4;
        }

        switch (result)
        {
            case 0:
                Debug.Log("you are mellow");
                m_Text.text = "You are mellow.";
                break;
            case 1:
                Debug.Log("you are relaxed");
                m_Text.text = "You are relaxed.";
                break;
            case 2:
                Debug.Log("you are anxious");
                m_Text.text = "They say you attract what you fear. Oh, do you wanna be scared of 10K?";
                break;
            case 3:
                Debug.Log("you are angry");
                m_Text.text = "If stress was a drug, you'd be overdosing! Chill out friend... ";
                break;
            case 4:
                Debug.Log("you are troubled");
                m_Text.text = "Apparently rock bottom has a basement...";
                break;
        }
    }
}
