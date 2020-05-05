using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSilent : MonoBehaviour
{
    public void RunSilence()
    {
        Manager.currentScene = Manager.ExistingScenes.silent;
    }
}
