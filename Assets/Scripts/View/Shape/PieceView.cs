using UnityEngine;
using UnityEngine.UI;

public class PieceView : MonoBehaviour
{
    private RectTransform _rectTransform;
    private BoxCollider2D _boxCollider;
    private DropZoneView _currentDropZone;
    private Anim _scaleAnim;
    private Anim _fadeAnim;
    [SerializeField] private bool _isActive;

    private void Awake()
    {
        _isActive = true;
        _scaleAnim = GetComponent<ScaleAnim>();
        _fadeAnim = GetComponent<FadeAnim>();
        _boxCollider = GetComponent<BoxCollider2D>();
        _rectTransform = GetComponent<RectTransform>();
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

    public bool IsActive() => _isActive;

    public void Disable(int i)
    {
        _isActive = false;
        _boxCollider.enabled = false;
        _scaleAnim.Play(PlayDelay: i * 0.1f);
        _fadeAnim.Play(OnAnimEnd, i * 0.1f);
    }

    private void OnAnimEnd()
    {
        Destroy(gameObject);
    }

    #region Triggers

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

    #endregion

    private void Recolor(Color color)
    {
        transform.GetComponent<Image>().color = color;
    }

    private void ClearDropZone()
    {
        Recolor(Color.white);
        _currentDropZone = null;
    }

}
