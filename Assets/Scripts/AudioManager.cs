using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource m_Source;
    public AudioClip screamClip;
    void Start()
    {
        m_Source = GetComponent<AudioSource>();
        m_Source.clip = screamClip;
    }

    // Update is called once per frame

    private bool soundOn = false;
    void Update()
    {
        if (Manager.isScreaming)
        {
            m_Source.PlayOneShot(screamClip);
        }
        else
        {
            m_Source.Stop();
        }
    }
}
