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
	
	[Inject]
	public void Constructor(IViewFabric fabric, IMarkerService markerService)
	{
		_markerService = markerService;
		_fabric = fabric;
	}

	public void ActivateService()
	{       
        _FieldView = _fabric.Init<FieldView>();
	}
}
