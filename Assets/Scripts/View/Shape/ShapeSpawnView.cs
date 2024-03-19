using UnityEngine;
using Zenject;

public class ShapeSpawnView : MonoBehaviour
{
	
}

public class ShapeSpawnViewService : IService
{
	private ShapeSpawnView _shapeSpawnView;
    [Inject] private IViewFabric _viewfabric;
    [Inject] private IServiceFabric _serviceFabric;
	private ShapeViewService _shapeViewService;
    [Inject] private IMarkerService _markerService;


	public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _shapeSpawnView = _viewfabric.Init<ShapeSpawnView>(parent);

        for (int i = 0; i < 3; i++)
		{
			_shapeViewService = _serviceFabric.InitMultiple<ShapeViewService>();
			_shapeViewService.ActivateService();
        }
	}
}
