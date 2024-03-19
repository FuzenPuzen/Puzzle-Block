using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    private RectTransform _rectTransform;
    private DropZone _currentDropZone;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<DropZone>(out DropZone dropZone))
            _currentDropZone = dropZone;
    }

    private void OnTriggerStay2D(Collider2D other)
    {      
        if (other.gameObject.TryGetComponent<DropZone>(out DropZone dropZone))
            _currentDropZone = dropZone;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DropZone>() == _currentDropZone)
            ClearDropZone();
    }

    public void ClearDropZone()
    {
        _currentDropZone = null;
    }

    public void Place()
    {
        transform.SetParent(_currentDropZone.transform);
        _rectTransform.anchoredPosition = Vector2.zero;
    }

    public bool CheckPlacement()
    {
        if (_currentDropZone != null && _currentDropZone.IsFree())
        {
            return true;
        }
        return false;
    }
}
