using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReplay : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        GameManager.currentScene = GameManager.ExistingScenes.intro;
    }
}
