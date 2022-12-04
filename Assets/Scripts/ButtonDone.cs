using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDone : MonoBehaviour
{
    public void RunEnding()
    {
        if (GameManager.currentScene == GameManager.ExistingScenes.voice && !GameManager.firstLoudScream)
        {
            GameManager.firstLoudScream = true;
            ES3.Save("firstLoudScream", GameManager.firstLoudScream);
        }
        else if (GameManager.currentScene == GameManager.ExistingScenes.silent && !GameManager.firstSilentScream)
        {
            GameManager.firstSilentScream = true;
            ES3.Save("firstSilentScream", GameManager.firstSilentScream);
        }

        GameManager.currentScene = GameManager.ExistingScenes.ending;
    }
}
