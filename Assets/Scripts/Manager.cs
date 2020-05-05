using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static Manager instance;
    public enum ExistingScenes
    {
        intro,
        voice,
        silent,
        ending,
    }

    public static ExistingScenes currentScene;

    public static bool isScreaming = false;

    public static float totalTimeScreaming= 0;
    private float screamInSeconds = 0;

    public static Vector3 screenDimensions;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
            Destroy(gameObject);
    }

    void Start()
    {
        currentScene = ExistingScenes.intro;
        screenDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
    }

    // Update is called once per frame
    void Update()
    {
        RunScenes();
        GameFlow();
        Debug.Log("curretn scene is "+currentScene);
        Debug.Log("active scene is "+SceneManager.GetActiveScene().name);
    }

    void RunScenes()
    {
        if (currentScene == ExistingScenes.intro)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Intro"))
            SceneManager.LoadScene("Intro");
        }
        else if (currentScene == ExistingScenes.silent)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Silent"))
                SceneManager.LoadScene("Silent");
        }
        else if (currentScene == ExistingScenes.voice)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Voice"))
                SceneManager.LoadScene("Voice");
        }
        else if (currentScene == ExistingScenes.ending)
        {
            if (SceneManager.GetActiveScene() != SceneManager.GetSceneByName("Ending"))
                SceneManager.LoadScene("Ending");
        }
    }

    void GameFlow()
    {
        if (currentScene == ExistingScenes.silent)
        {
            CountScreamingTime();
        }
        else if (currentScene == ExistingScenes.voice)
        {
            CountScreamingTime();
        }
        else if (currentScene == ExistingScenes.ending)
        {
            RevealScreamedSeconds();
            Debug.Log("Scream in seconds are "+totalSecs);
        }
    }
    

    public void RunEnding()
    {
        Debug.Log("ren ending now");
        currentScene = ExistingScenes.ending;
        Debug.Log(currentScene);
    }

    public void CountScreamingTime()
    {
        if (isScreaming)
        {
            totalTimeScreaming += Time.deltaTime;
        }
    }

    public static int totalSecs;
    public void RevealScreamedSeconds()
    {
        screamInSeconds = totalTimeScreaming % 60;
        totalSecs = (int) screamInSeconds;
    }

}
