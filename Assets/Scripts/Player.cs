using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool isScreaming = false;
    public Sprite defaultImg;
    public Sprite screamingImg;

    SpriteRenderer m_Renderer;
    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        m_Renderer.sprite = defaultImg;
        
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (isScreaming)
        {
            m_Renderer.sprite = screamingImg;
        }
        else
        {
            m_Renderer.sprite = defaultImg;
        }
    }

    public void ScreamTime()
    {
        isScreaming = true;
    }
}
