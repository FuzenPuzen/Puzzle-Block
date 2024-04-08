using System;
using UnityEngine;
using Zenject;

public interface IAudioDataManager
{
    public AudioClip GetAudioSOData(AudioEnum audioName);
    public AudioSLData GetAudioSLData();
    public void SetAudioSLData(AudioSLData audioSLData);
}


public class AudioDataManager : IAudioDataManager
{
    private const string AudioKey = "AudioKey";
    private ISOStorageService _storageService;
    private AudioSOData _audioSOData;
    private AudioSLData _audioSLData;

    [Inject]
    public void Constructor(ISOStorageService sOStorageService)
    {
        _storageService = sOStorageService;
        _audioSOData = (AudioSOData)_storageService.GetSOByType<AudioSOData>();
        LoadAudioData();
    }

    public AudioClip GetAudioSOData(AudioEnum audioName) => _audioSOData.audioDictionary[audioName];
    public AudioSLData GetAudioSLData() => _audioSLData;
    public void SetAudioSLData(AudioSLData audioSLData)
    {
        _audioSLData = audioSLData;
        _audioSLData.MusicValue = Math.Clamp(_audioSLData.MusicValue, 0, 1);
        _audioSLData.SoundValue = Math.Clamp(_audioSLData.SoundValue, 0, 1);
        SaveLoader.SaveItem<AudioSLData>(_audioSLData, AudioKey);
    }

    public void LoadAudioData()
    {
        _audioSLData = new();
        _audioSLData = SaveLoader.LoadData(_audioSLData, AudioKey);      
    }
}

public class AudioSLData
{
    public float MusicValue;
    public float SoundValue;
}
