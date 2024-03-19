using Zenject;
using UnityEngine;

public class GameCanvasView : MonoBehaviour
{

}

public class GameCanvasViewService : IService
{
	private IViewFabric _viewFabric;
	private GameCanvasView _GameCanvasView;
    private IMarkerService _markerService;
	
	[Inject]
	public void Constructor(IViewFabric fabric, IMarkerService markerService)
	{
		_markerService = markerService;
		_viewFabric = fabric;
	}

	public void ActivateService()
	{       
        _GameCanvasView = _viewFabric.Init<GameCanvasView>();
	}
}
