using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSilent : MonoBehaviour
{
    public void RunSilence()
    {
        GameManager.currentScene = GameManager.ExistingScenes.silent;
    }
}
