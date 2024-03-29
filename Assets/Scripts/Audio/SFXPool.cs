using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GeneralUtils.Core.Singleton;

public class SFXPool : Singleton<SFXPool>
{
    private List<AudioSource> _audioSourceList;
    public int poolSize = 10;

    private int _index = 0;

    private void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        _audioSourceList = new List<AudioSource>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateAudioSoruceItem();
        }
    }

    private void CreateAudioSoruceItem()
    {
        GameObject go = new GameObject("SFX_Pool");
        go.transform.SetParent(gameObject.transform);
        _audioSourceList.Add(go.AddComponent<AudioSource>());
    }

    public void Play(SFXType sFXType)
    {
        if (sFXType == SFXType.NONE) return;
        var sfx = SoundManager.Instance.GetSfxByType(sFXType);

        _audioSourceList[_index].clip = sfx.audioClip;
        _audioSourceList[_index].Play();
        _index++;
        if (_index >= _audioSourceList.Count) _index = 0;
        
    }
}
