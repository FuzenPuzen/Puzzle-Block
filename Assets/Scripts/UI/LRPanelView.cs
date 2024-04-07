using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;
using EventBus;
using TMPro;
using System.Collections.Generic;

public class LRPanelView : MonoBehaviour
{
	[SerializeField] private Button _restartButton;
	[SerializeField] private Button _cancelButton;
	[SerializeField] private TMP_Text _headerText;
    public Action OnRestartButtonAction;
    [SerializeField] private List<string> _looseTexts = new();
    [SerializeField] private List<string> _restartTexts = new();

    private void Awake()
    {        
        _restartButton.onClick.AddListener(OnRestart);
        _cancelButton.onClick.AddListener(HideView);
    }

    private void OnRestart()
    {
        OnRestartButtonAction?.Invoke();
    }

    public void RestartState()
    {
        int RandomID = UnityEngine.Random.Range(0, _restartTexts.Count);
        _headerText.text = _restartTexts[RandomID];
        _cancelButton.gameObject.SetActive(true);
    }

    public void LooseState()
    {
        int RandomID = UnityEngine.Random.Range(0, _looseTexts.Count);
        _headerText.text = _looseTexts[RandomID];
        _cancelButton.gameObject.SetActive(false);
    }

    public void HideView()
    {
        gameObject.SetActive(false);
        transform.localScale = Vector3.zero;
    }

    public void ShowView()
    {
        gameObject.SetActive(true);
    }
}

public class LoosePanelViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private LRPanelView _LoosePanelView;
    [Inject] private IMarkerService _markerService;

	public void ActivateService()
	{
        Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _LoosePanelView = _viewFabric.Init<LRPanelView>(parent);
        _LoosePanelView.OnRestartButtonAction = Onrestart;
        _LoosePanelView.LooseState();
        _LoosePanelView.HideView();
    }

    public void Onrestart()
    {
        EventBus<OnRestart>.Raise();
    }

    public void HideView()
    {
        _LoosePanelView.HideView();
    }

    public void ShowView()
    {
        _LoosePanelView.LooseState();
        _LoosePanelView.ShowView();
    }
}
