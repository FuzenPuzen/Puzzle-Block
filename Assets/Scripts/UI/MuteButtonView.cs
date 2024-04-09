using Zenject;
using UnityEngine;
using UnityEngine.UI;
using System;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(ScaleShakeAnim))]
public class MuteButtonView : MonoBehaviour
{
	private Button _mutetButton;
	private ScaleShakeAnim _scaleShakeAnim;
	[SerializeField] private Sprite _muteImage;
	[SerializeField] private Sprite _unMuteImage;

	private Action OnClickAction;
	public Action OnMuteButtonAction;
	public Action OnUnMuteButtonAction;

	private void Awake()
	{
        _mutetButton = GetComponent<Button>();
        _scaleShakeAnim = GetComponent<ScaleShakeAnim>();
        _mutetButton.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
        _scaleShakeAnim.Play();
        OnClickAction?.Invoke();
	}

	public void SetMute()
	{
        OnClickAction = OnUnMuteButtonAction;
        _mutetButton.image.sprite = _muteImage;
    }

    public void SetUnMute()
    {
        OnClickAction = OnMuteButtonAction;
        _mutetButton.image.sprite = _unMuteImage;
    }

}

public class MuteButtonViewService : IService
{
	[Inject] private IViewFabric _viewFabric;
	private MuteButtonView _muteButtonView;
    [Inject] private IMarkerService _markerService;
    [Inject] private IAudioDataManager _audioDataManager;
	
	public void ActivateService()
	{       
		Transform parent = _markerService.GetMarker<GameCanvasMarker>().transform;
        _muteButtonView = _viewFabric.Init<MuteButtonView>(parent);
		_muteButtonView.OnMuteButtonAction = OnMuteAction;
        _muteButtonView.OnUnMuteButtonAction = UnMuteAction;
        _muteButtonView.SetUnMute();
    }

	public void OnMuteAction()
	{
		_audioDataManager.SetMute();
        _muteButtonView.SetMute();
    }

	public void UnMuteAction()
	{
		_audioDataManager.SetMax();
        _muteButtonView.SetUnMute();
    }
	
}
