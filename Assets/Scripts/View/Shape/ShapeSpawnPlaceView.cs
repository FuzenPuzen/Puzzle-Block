using UnityEngine;
using Zenject;

public class ShapeSpawnPlaceView : MonoBehaviour
{
	
}

public class ShapeSpawnPlaceViewService : IService
{
	private ShapeSpawnPlaceView _shapeSpawnView;
    [Inject] private IViewFabric _viewfabric;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _shapeSpawnView = _viewfabric.Init<ShapeSpawnPlaceView>(parent);
	}
}
