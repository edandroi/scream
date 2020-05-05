using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonLoud : MonoBehaviour
{
    public void RunVoice()
    {
        Manager.currentScene = Manager.ExistingScenes.voice;
    }
}
