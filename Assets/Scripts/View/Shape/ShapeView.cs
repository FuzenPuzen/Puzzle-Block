using EventBus;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShapeView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform _rectTransform;
    private Vector2 _startPosition;

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
        EventBus<ShapePlaced>.Raise();
    }
}
