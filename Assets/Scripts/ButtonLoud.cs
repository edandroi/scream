using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoud : MonoBehaviour
{

    public void RunVoice()
    {
        GameManager.currentScene = GameManager.ExistingScenes.voice;
    }
    
}
