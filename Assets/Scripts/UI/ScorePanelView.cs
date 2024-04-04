using Zenject;
using UnityEngine;
using TMPro;
using EventBus;

public class ScorePanelView : MonoBehaviour
{
	[SerializeField] private TMP_Text _scoreText;

    public void UpdateScore(int score)
    {
        _scoreText.text = "Ñ÷¸ò: " + score.ToString();
    }
}

public class ScorePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private ScorePanelView _ScorePanelView;
    [Inject] private IMarkerService _markerService;
    private EventBinding<ScoreChanged> _scoreChanged;


    public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _ScorePanelView = _viewFabric.Init<ScorePanelView>(parent);
        _scoreChanged = new(UpdateScore);
    }
    public void DeactivateService() 
    { 
        _scoreChanged.Remove(UpdateScore);
    }

    private void UpdateScore(ScoreChanged scoreChanged)
    {
        _ScorePanelView.UpdateScore(scoreChanged.score);
    }
}
