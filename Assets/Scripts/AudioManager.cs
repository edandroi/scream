using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource m_Source;
    public AudioClip screamClip;
    private AudioManager instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else if (instance != this)
            Destroy(gameObject);
    }
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
    }

    public void AdjustPitch(float pitch)
    {
        m_Source.pitch = pitch;
        
    }
    
    public void AdjustVolume(float volume)
    {
        m_Source.volume = volume;
        m_Source.volume = Mathf.Clamp(m_Source.volume, 0.2f, 1f);
    }
}
