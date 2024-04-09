using EventBus;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ShapeView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _startPosition;
    private Transform _shape;
    private Vector3 _shapeStartScale;
    private float _multiDrag;
    public Action ShapePlaced;
    public Action OnTake;

    private void Awake()
    {
        _shape = transform.GetChild(0);
        _shapeStartScale = _shape.transform.localScale;
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetMultiDrag(float multiDrag)
    {
        _multiDrag = multiDrag;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnTake.Invoke();
        _shape.transform.localScale = Vector3.one;
        _startPosition = _rectTransform.anchoredPosition;
        _rectTransform.anchoredPosition += new Vector2(0, 150);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta * _multiDrag;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int childcount = transform.GetChild(0).childCount;
        var shape = transform.GetChild(0);

        for (int i = 0; i < childcount; i++)
        {
            if (!shape.GetChild(i).GetComponent<PieceView>().CheckPlacement())
            {                
                _rectTransform.anchoredPosition = _startPosition;
                _shape.transform.localScale = _shapeStartScale;
                return;
            }
        }

        for (int i = 0; i < childcount; i++)
        {
            shape.GetChild(0).GetComponent<PieceView>().Place();
        }

        ShapePlaced.Invoke();
        Destroy(gameObject);
    }
}

public class ShapeViewService : IService
{
    [Inject] private IViewFabric _viewfabric;
    private ShapeView _shapeView;
    [Inject] private IMarkerService _markerService;
    [Inject] private IAudioService _audioService;
    [Inject] private GameCanvasViewService _gameCanvasViewService;
    public ShapeData ShapeData;


    public void ActivateService()
    {
        Transform parent = _markerService.GetMarker<ShapePlaceMarker>().transform;
        _shapeView = _viewfabric.Init<ShapeView>(ShapeData.Prefab, parent);
        _shapeView.ShapePlaced += OnShapePlaced;
        _shapeView.OnTake += OnShapeTake;
        _shapeView.SetMultiDrag(CalculateMultiDrag());
    }

    public float CalculateMultiDrag()
    {
        Canvas _canvas = _gameCanvasViewService.GetCanvas();        
        return _canvas.GetComponent<RectTransform>().rect.width / Screen.width;
    }

    public void OnShapeTake()
    {
        _audioService.PlayAudio(AudioEnum.Take, false);
    }

    public void OnShapePlaced()
    {
        _audioService.PlayAudio(AudioEnum.Put, false);
        EventBus<OnShapePlaced>.Raise(new OnShapePlaced { shapeViewService = this });
    }

    public void SetShape(ShapeData shape)
    {
        ShapeData = shape;
    }
}
