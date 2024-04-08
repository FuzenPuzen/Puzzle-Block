using Zenject;
using UnityEngine;
using System;
using System.Collections;

public class AudioUnitView : MonoBehaviour
{
    public Action DeactivateToPool;

    private AudioSource _audioSource;

    public void Awake()
    {
        gameObject.SetActive(false);
        _audioSource = GetComponent<AudioSource>();
    }

    public void ActivateView(StartValues startValues, float volume)
    {
        gameObject.SetActive(true);
        _audioSource.loop = startValues.IsLoopClip;
        _audioSource.clip = startValues.Clip;
        _audioSource.volume = volume;

        _audioSource.Play();

        if (startValues.IsLoopClip == false) StartCoroutine(AudioDelay(startValues.Clip.length));
    }
    private IEnumerator AudioDelay(float audioLenght)
    {
        yield return new WaitForSeconds(audioLenght);
        DeactivateToPool?.Invoke();
    }
    public void DeactivateView()
    {
        _audioSource.loop = false;
        _audioSource.clip = null;
        gameObject.SetActive(false);
    }
}

public class StartValues
{
    public bool IsLoopClip = false;
    public AudioClip Clip;
}

public class AudioUnitViewService : IPoolingViewService
{
    [Inject] private IViewFabric _fabric;
	private AudioUnitView _audioUnitView;
    [Inject] private IAudioDataManager _audioDataManager;
    private Action<IPoolingViewService> _onDeactivateAction;

    public void Play(StartValues startValues = null)
    {
        float volume = _audioDataManager.GetAudioSLData().SoundValue;
        _audioUnitView.ActivateView(startValues, volume);
    }

    public void ActivateServiceFromPool(Transform poolTarget)
    {
        if (_audioUnitView == null)
        {
            Vector3 spawnPos = poolTarget.position;
            _audioUnitView = _fabric.Init<AudioUnitView>(spawnPos, poolTarget);
            _audioUnitView.DeactivateToPool = DeactivateServiceToPool;
        }
    }

    public void DeactivateServiceToPool()
    {
        _audioUnitView.DeactivateView();
        _onDeactivateAction?.Invoke(this);
    }

    public void SetDeactivateAction(Action<IPoolingViewService> action)
    {
        _onDeactivateAction = action;
    }
}
