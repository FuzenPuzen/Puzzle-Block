using Zenject;
using UnityEngine;

public class FieldView : MonoBehaviour
{

}

public class FieldViewService : IService
{
	private IViewFabric _fabric;
	private FieldView _FieldView;
    private IMarkerService _markerService;
	private DropZoneView[,] _fieldPoints = new DropZoneView[10,10];
	
	[Inject]
	public void Constructor(IViewFabric fabric, IMarkerService markerService)
	{
		_markerService = markerService;
		_fabric = fabric;
	}

	public DropZoneView[,] GetFiledPoints() => _fieldPoints;


    public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _FieldView = _fabric.Init<FieldView>(parent);
		for (int i = 0; i < 10; i++)
			for (int j = 0; j < 10; j++)
			{
				_fieldPoints[j, i] = _fabric.Init<DropZoneView>(_FieldView.transform);
				_fieldPoints[j, i].point = new Vector2(j, i);
            }
	}
}
