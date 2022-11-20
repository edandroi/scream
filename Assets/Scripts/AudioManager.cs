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
        m_Source.playOnAwake = false;
        m_Source.clip = screamClip;
    }

    public void PlayScream()
    {
        m_Source.Play();
        m_Source.loop = true;
    }

    public void StopScream()
    {
        m_Source.Stop();
        m_Source.clip = null;
    }
}
