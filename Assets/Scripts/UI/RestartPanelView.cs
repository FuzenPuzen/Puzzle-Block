using Zenject;
using UnityEngine;
using EventBus;

public class RestartPanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private LRPanelView _LRPanelView;
    [Inject] private IMarkerService _markerService;
	
	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _LRPanelView = _viewFabric.Init<LRPanelView>(parent);
        _LRPanelView.OnRestartButtonAction = Onrestart;
        _LRPanelView.RestartState();
        _LRPanelView.HideView();
    }

    public void Onrestart()
    {
        EventBus<OnRestart>.Raise();
    }

    public void HideView()
	{
        _LRPanelView.HideView();
	}
	
	public void ShowView()
	{
        _LRPanelView.RestartState();
        _LRPanelView.ShowView();
	}
}
