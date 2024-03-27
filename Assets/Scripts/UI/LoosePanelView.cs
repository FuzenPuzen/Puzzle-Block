using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;
using EventBus;

public class LoosePanelView : MonoBehaviour
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

public class LoosePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private LoosePanelView _LoosePanelView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _LoosePanelView = _viewFabric.Init<LoosePanelView>(parent);
        _LoosePanelView.OnRestartButtonAction = Onrestart;
        _LoosePanelView.HideView();

    }

    public void Onrestart()
    {
        EventBus<OnRestart>.Raise();
    }

    public void HideView()
    {
        _LoosePanelView.HideView();
    }

    public void ShowView()
    {
        _LoosePanelView.ShowView();
    }
}
