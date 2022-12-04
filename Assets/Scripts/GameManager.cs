using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private Color32 mainBgColor = new Color32(251, 132, 116, 0);
    Color32 screamColor = new Color32(221, 69, 55,0);

    private bool isMobile = false;

    private GameObject touchTracker;
    private GameObject screamModifier;
    
    public static bool firstLoudScream;
    public static bool firstSilentScream;
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

    public static bool initialPlay = true;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
            Destroy(gameObject);
        
        touchTracker = new GameObject();
        touchTracker.name = "Touch Tracker";
        touchTracker.AddComponent<TouchTracker>();
        
        screamModifier = new GameObject();
        touchTracker.name = "Scream Modifier";
        screamModifier.AddComponent<ScreamModifier>();

        
        if(ES3.KeyExists("initialPlay"))
            initialPlay = ES3.Load<bool>("initialPlay");
    }

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            isMobile = true;
        }
        
        if(ES3.KeyExists("firstLoudScream"))
            firstLoudScream = ES3.Load<bool>("firstLoudScream");
        if(ES3.KeyExists("firstSilentScream"))
            firstSilentScream = ES3.Load<bool>("firstSilentScream");
        
        currentScene = ExistingScenes.intro;
    }
    
    void Update()
    {
        RunScenes();
        GameFlow();
    }
    
    void RunScenes()
    {
        if (currentScene == ExistingScenes.intro)
        {
            totalTimeScreaming = 0;
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
            
            if (isScreaming)
            {
                Camera.main.backgroundColor = screamColor;

                if (isMobile)
                {
                    Debug.Log("vibrating now");
                    Handheld.Vibrate();
                }
            }
            else
            {
                Camera.main.backgroundColor = mainBgColor;
            }
        }
        else if (currentScene == ExistingScenes.voice)
        {
            CountScreamingTime();

            if (isScreaming)
            {
                Camera.main.backgroundColor = screamColor;
                if (isMobile)
                {
                    Handheld.Vibrate();
                }
            }
            else
            {
                Camera.main.backgroundColor = mainBgColor;
            }

        }
        else if (currentScene == ExistingScenes.ending)
        {
            RevealScreamedSeconds();
        }
    }

    void SetBackgroundColor()
    {
        if (Camera.main.backgroundColor != mainBgColor)
            if (!isScreaming)
                Camera.main.backgroundColor = mainBgColor;
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
