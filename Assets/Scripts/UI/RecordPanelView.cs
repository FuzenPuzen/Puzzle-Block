using Zenject;
using UnityEngine;
using TMPro;
using EventBus;

public class RecordPanelView : MonoBehaviour
{
	[SerializeField] private TMP_Text _record;

	public void UpdateView(int record)
	{
        _record.text = record.ToString();
    }
}

public class RecordPanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private RecordPanelView _RecordPanelView;
    [Inject] private IMarkerService _markerService;
    [Inject] private IRecordDataManager _recordDataManager;
    private EventBinding<RecordChanged> _recordChanged;

    public void ActivateService()
	{
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _RecordPanelView = _viewFabric.Init<RecordPanelView>(parent);
		UpdateView();
        _recordChanged = new(UpdateView);
    }

    public void DeactivateService()
    {
        _recordChanged.Remove(UpdateView);
    }

	public void UpdateView()
	{
        _RecordPanelView.UpdateView(_recordDataManager.GetRecord());
    }
}
