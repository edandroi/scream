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
        totalScreamDuration = GameManager.totalSecs;
        
        Debug.Log(GetComponent<TextMeshProUGUI>());
        m_Text = GetComponent<TextMeshProUGUI>();

        AnalyzeScream();
    }

    void AnalyzeScream()
    {
        int result = 0;

        if (totalScreamDuration < 2)
        {
            // lvl0
            result = 0;
        }
        else if (totalScreamDuration >= 2 && totalScreamDuration < 4)
        {
            // lvl1
            result = 1;
        }
        else if (totalScreamDuration >= 4 && totalScreamDuration < 7)
        {
            // lvl2
            result = 2;
        }
        else if (totalScreamDuration >= 7 && totalScreamDuration < 10)
        {
            // lvl3
            result = 3;
        }
        else if (totalScreamDuration >= 10 && totalScreamDuration < 14 )
        {
            // lvl4
            result = 4;
        }
        else if (totalScreamDuration >= 14 && totalScreamDuration < 17)
        {
            // lvl5
            result = 5;
        }
        else if (totalScreamDuration >= 17 && totalScreamDuration < 23)
        {
            // lvl6
            result = 6;
        }
        else if (totalScreamDuration >= 23 && totalScreamDuration < 28)
        {
            // lvl7
            result = 7;
        }
        else if (totalScreamDuration >= 28 && totalScreamDuration < 35)
        {
            // lvl8
            result = 8;
        }

        switch (result)
        {
            case 0: // lvl0 Mellow
                m_Text.text = "You are mellow just like a marshmallow!";
                break;
            case 1: // lvl1
                m_Text.text = "You are fine, the moment is gone.";
                break;
            case 2: // lvl2
                m_Text.text = "Okay, you had a moment. All okay now. Doing well, again.";
                break;
            case 3: // lvl3
                m_Text.text = "Have you tired breathing in and out again?";
                break;
            case 4: // lvl4
                m_Text.text = "If stress was a drug, you'd be overdosing! Chill out friend... ";
                break;
            case 5: // lvl5
                m_Text.text = "Oh no. Oh no... Oh no, no, NO NO NO!";
                break;
            case 6: // lvl6
                m_Text.text = "Is this even helping you for real?";
                break;
            case 7: // lvl7
                m_Text.text = "Your therapist must be rich by now...";
                break;
            case 8: // lvl8
                m_Text.text = "Something is awfully wrong with you...Please quit the app and call 911!";
                break;
        }
    }
}
