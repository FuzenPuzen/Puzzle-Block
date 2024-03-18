using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropUI : MonoBehaviour
{
    private RectTransform _rectTransform;
    private DropZone _currentDropZone;
    private DropZone _prevDropZone;
    public bool isCanPlace;

    private void Awake()
    {
        isCanPlace = false;
        _rectTransform = GetComponent<RectTransform>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Void>())
        {
            _currentDropZone = null;
            _prevDropZone = null;
            isCanPlace = false;
            return;
        }

        if (other.gameObject.GetComponent<DropZone>() != null)
        {
            isCanPlace = true;
            _currentDropZone = other.GetComponent<DropZone>();
            if (_prevDropZone != null && _prevDropZone != _currentDropZone)
                _prevDropZone.Recolor(Color.white);
            if (_prevDropZone == null)
                _prevDropZone = _currentDropZone;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DropZone>() != null)
        {
            _currentDropZone = other.GetComponent<DropZone>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DropZone>() == _currentDropZone)
        {
            _currentDropZone = _prevDropZone;
            return;
        }
        _prevDropZone = _currentDropZone;
    }

    public void Place()
    {
        if (_currentDropZone != null)
        {
            transform.SetParent(_currentDropZone.transform);
            _rectTransform.anchoredPosition = Vector2.zero;
        }
    }

    public bool CheckPlacement()
    {
        if (_currentDropZone != null && _currentDropZone.IsFree())
        {
            return isCanPlace;
        }
        return false;
    }
}
