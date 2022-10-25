using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;

public class SoundManager : Singleton<SoundManager>
{
    public List<MusicSetup> musicSetups;
    public List<SFXSetup> sFXSetups;

    public AudioSource musicSource;
    private bool _isPlaying=true;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M) && _isPlaying)
        {
            musicSource.Stop();
            _isPlaying = false;
        }
        else if (Input.GetKeyDown(KeyCode.M) && !_isPlaying)
        {
            musicSource.Play();
        }
    }
    public void PlayMusicByType(MusicType musicType)
    {
        var music = GetPlayMusicByType(musicType);
        musicSource.clip = music.audioClip;
        musicSource.Play();
    }

    //Music
    public MusicSetup GetPlayMusicByType(MusicType musicType)
    {
        return musicSetups.Find(i => i.musicType == musicType);
    }

    //  SFX
    
    public SFXSetup GetSfxByType(SFXType sfxType)
    {
        return sFXSetups.Find(i => i.sFXType == sfxType);
    }
}


public enum MusicType
{
    TYPE_01,
    TYPE_02,
    TYPE_03,
}

[System.Serializable]
public class MusicSetup
{
    public  MusicType musicType;
    public AudioClip audioClip;
}

public enum SFXType
{
    NONE,
    TYPE_01,
    TYPE_02,
    TYPE_03,
}


[System.Serializable]
public class SFXSetup
{
    public SFXType sFXType;
    public AudioClip audioClip;
}