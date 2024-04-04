using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;
using EventBus;

public class RestartButtonView : MonoBehaviour
{

	[SerializeField] private Button _restartButton;
	public Action OnRestartButtonAction;

	private void Awake()
	{        
		_restartButton.onClick.AddListener(OnRestart);
	}

	private void OnRestart()
	{
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
	
	public void ActivateService()
	{       
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _RestartButtonView = _viewFabric.Init<RestartButtonView>(parent);
		_RestartButtonView.OnRestartButtonAction = OnrestartButton;

    }

    public void OnrestartButton()
    {
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
