using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamObjectManager : MonoBehaviour
{
    public GameObject screamObj;

    private Vector3 stageDimensions;

    float timerNewScream = .2f;

    float timerMin = .05f;
    float timerMax = .2f;
    void Start()
    { 
        // (0,0) on screen is the bottom left coordinates
        stageDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isScreaming)
        {
            timerNewScream -= Time.deltaTime;
//            float xCoord = Random.Range(0, stageDimensions.x);
//            float yCoord = Random.Range(0, stageDimensions.y);
        }

        if (timerNewScream < 0)
        {
            float xCoord = Random.Range(-stageDimensions.x, stageDimensions.x);
            float yCoord = Random.Range(-stageDimensions.y, stageDimensions.y);

            Vector3 spawnPos = new Vector3(xCoord, yCoord, 0);
            Instantiate(screamObj,spawnPos, Quaternion.identity);

            timerNewScream = Random.Range(timerMin, timerMax);
        }
    }
}
