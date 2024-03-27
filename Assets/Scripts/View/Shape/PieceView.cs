using UnityEngine;
using UnityEngine.UI;

public class PieceView : MonoBehaviour
{
    private RectTransform _rectTransform;
    private DropZoneView _currentDropZone;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<DropZoneView>(out DropZoneView dropZone))
        {
            _currentDropZone = dropZone;
            if (!_currentDropZone.IsFree()) Recolor(Color.red);
            else Recolor(Color.white);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {      
        if (other.gameObject.TryGetComponent<DropZoneView>(out DropZoneView dropZone))
            _currentDropZone = dropZone;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<DropZoneView>() == _currentDropZone)
            ClearDropZone();
    }

    private void Recolor(Color color)
    {
        transform.GetComponent<Image>().color = color;
    }

    public void ClearDropZone()
    {
        Recolor(Color.white);
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
