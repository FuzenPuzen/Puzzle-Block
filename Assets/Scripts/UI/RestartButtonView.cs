using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;
using EventBus;

[RequireComponent(typeof(RotateAnim))]
[RequireComponent(typeof(Button))]
public class RestartButtonView : MonoBehaviour
{

	private Button _restartButton;
	private RotateAnim _rotateAnim;
	public Action OnRestartButtonAction;

	private void Awake()
	{
        _restartButton = GetComponent<Button>();
        _rotateAnim = GetComponent<RotateAnim>();
        _restartButton.onClick.AddListener(OnRestart);
	}

	private void OnRestart()
	{
        _rotateAnim.Play();
        OnRestartButtonAction?.Invoke();
	}

	public void HideView()
	{
		gameObject.SetActive(false);
	}

	public void ShowView()
	{
		gameObject.SetActive(true);
	}

}

public class RestartButtonViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private RestartButtonView _RestartButtonView;
    [Inject] private IMarkerService _markerService;
    [Inject] private IAudioService _audioService;

    public void ActivateService()
	{       
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _RestartButtonView = _viewFabric.Init<RestartButtonView>(parent);
		_RestartButtonView.OnRestartButtonAction = OnrestartButton;

    }

    public void OnrestartButton()
    {
		_audioService.PlayAudio(AudioEnum.Restart, false);
        EventBus<OnRestartButton>.Raise();
    }

    public void HideView()
	{
        _RestartButtonView.HideView();
	}
	
	public void ShowView()
	{
        _RestartButtonView.ShowView();
	}
}
