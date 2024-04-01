using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TutorialView : MonoBehaviour
{

	[SerializeField] private Button _closeButton;
	public Action OnCloseButtonAction;

	private void Awake()
	{        
		_closeButton.onClick.AddListener(HideView);
	}

	public void HideView()
	{
		gameObject.SetActive(false);
	}

	public void ShowView()
	{
		gameObject.SetActive(true);
	}

}

public class TutorialViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private TutorialView _tutorialView;
    [Inject] private IMarkerService _markerService;
	private int _isTutorial = 1;
	
	public void ActivateService()
	{
		if (PlayerPrefs.HasKey("isTutorial"))
            _isTutorial = PlayerPrefs.GetInt("isTutorial");
        if (_isTutorial == 1)
		{
			Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
			_tutorialView = _viewFabric.Init<TutorialView>(parent);
			PlayerPrefs.SetInt("isTutorial", 0);
        }
	}
	
	public void HideView()
	{
        _tutorialView.HideView();
	}
	
	public void ShowView()
	{
        _tutorialView.ShowView();
	}
}
