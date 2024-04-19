using UnityEngine;
using Zenject;

public class ShapeSpawnPlaceView : MonoBehaviour
{
    public void Clear()
    {
		for (int i = 0; i < transform.childCount; i++)
			Destroy(transform.GetChild(i).gameObject);
    }
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

	public void Clear()
	{
        _shapeSpawnView.Clear();

    }
}
