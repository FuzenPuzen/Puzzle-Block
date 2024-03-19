using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Shape : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
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
            if (!transform.GetChild(i).GetComponent<Piece>().CheckPlacement())
            {                
                _rectTransform.anchoredPosition = _startPosition;
                return;
            }
        }
        for (int i = 0; i < childcount; i++)
        {                
            transform.GetChild(0).GetComponent<Piece>().Place();
        }
    }
}
