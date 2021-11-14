using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioMixerGroup musicMixerGroup;
    [SerializeField] private AudioMixerGroup effectMixerGroup;
    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            switch (s.audioType)
            {
                case Sound.AudioTypes.soundEffect:
                    s.source.outputAudioMixerGroup = effectMixerGroup;
                    break;
                case Sound.AudioTypes.Music:
                    s.source.outputAudioMixerGroup = musicMixerGroup;
                    break;
            }
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    public void UpdateMixerVolume()
    {
        musicMixerGroup.audioMixer.SetFloat("Music Volume", Mathf.Log10(AudioOptionsManager.musicVolume) * 20);
        effectMixerGroup.audioMixer.SetFloat("Effect Volume", Mathf.Log10(AudioOptionsManager.soundEffectVolume) * 20);   
    }
}
