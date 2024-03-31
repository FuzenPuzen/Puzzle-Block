using Zenject;
using UnityEngine;
using TMPro;

public class LoggerView : MonoBehaviour
{
    [SerializeField] private TMP_Text ShapePos;
    [SerializeField] private TMP_Text TouchPos;

    public void UpdateShapePos()
    {
        
    }

    public void UpdateTouchPos()
    {

    }
}

public class LoggerViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private LoggerView _LoggerView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _LoggerView = _viewFabric.Init<LoggerView>(parent);
	}

    public void UpdateShapePos()
    {
        _LoggerView.UpdateShapePos();
    }

    public void UpdateTouchPos()
    {
        _LoggerView.UpdateTouchPos();
    }
}
