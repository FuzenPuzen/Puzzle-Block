using EventBus;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class ShapeView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _startPosition;
    public Action ShapePlaced;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _startPosition = _rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int childcount = transform.childCount;
        for (int i = 0; i < childcount; i++)
        {
            if (!transform.GetChild(i).GetComponent<PieceView>().CheckPlacement())
            {                
                _rectTransform.anchoredPosition = _startPosition;
                return;
            }
        }
        for (int i = 0; i < childcount; i++)
        {                
            transform.GetChild(0).GetComponent<PieceView>().Place();
        }
        ShapePlaced.Invoke();
        Destroy(gameObject); // временно
    }
}

public class ShapeViewService : IService
{
    private IViewFabric _viewfabric;
    private ShapeView _shapeView;
    private IMarkerService _markerService;
    public ShapeData ShapeData;

    [Inject]
    public void Constructor(IViewFabric fabric, IMarkerService markerService)
    {
        _markerService = markerService;
        _viewfabric = fabric;
    }

    public void ActivateService()
    {
        Transform parent = _markerService.GetMarker<ShapePlaceMarker>().transform;
        _shapeView = _viewfabric.Init<ShapeView>(ShapeData.Prefab, parent);
        _shapeView.ShapePlaced += OnShapePlaced;
    }

    public void OnShapePlaced()
    {
        EventBus<ShapePlaced>.Raise(new ShapePlaced { shapeViewService = this });
    }

    public void SetShape(ShapeData shape)
    {
        ShapeData = shape;
    }
}
